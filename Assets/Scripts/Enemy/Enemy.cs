
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using TMPro;

public class Enemy : MonoBehaviour
{
    //public float speed; //��������
    GameObject player; //�����
    public int health = 2; //�����
    public int damage; //���� �� �������
    public int coinValue = 0; //���� �� �����������
    public GameObject deathEffect; //������ ������
    float dist;
    public Transform[] spawnPoints; //����� ��������������
    int randomSpawn; //������ ����� ������
    float waitTime;
    public float startWaitTime;
    public GameObject[] objBonus = new GameObject[3];
    public int[] dropChance = new int[3];
    int randBonus;
    
    public GameObject spawnEffect; //������ ������
    //public bool enemyRage = false;
    [Header("���� �� ����� � �����")]
    public bool isBomb = false; //����� �� ���� ���������� �����
    public GameObject bomb;
    [Header("���� �� ������ � �����")]
    public bool isRocket = false; //����� �� ���� ���������� �����
    public GameObject FloatingPoints;
    public GameObject FloatingPointsCombo;

    private float speedTimerLimit = 3f; //�������� �������� �� 0
    private float speedTimer = 0f;
    float speed;


    public NavMeshAgent agent;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        //������ ������ ����� ��� ��������������
        GameObject[] _obj = GameObject.FindGameObjectsWithTag("SpawnPoints");
        spawnPoints = new Transform[_obj.Length];
        for (int i = 0; i < spawnPoints.Length; i++)
            spawnPoints[i] = _obj[i].GetComponent<Transform>();

        //������ ��������� ����� ��� ��������������
        randomSpawn = Random.Range(0, spawnPoints.Length);
        waitTime = startWaitTime;

        //������ ������ ��� �������� �����
        GameObject effect = Instantiate(spawnEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.3f);

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        //isCoins = true;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerController player = hitInfo.GetComponent<PlayerController>();
        Shield shield = hitInfo.GetComponent<Shield>();

        if (player != null)
        {
            AudioManager.instance.Play("EnemyDie");
            player.TakeDamage(damage);
            Destroy(gameObject);
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.3f);
        }

        if (shield != null)
        {
            AudioManager.instance.Play("EnemyDie");
            shield.TakeDamage(damage);
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.3f);
            Destroy(gameObject);

            //Debug.Log(EnemyBullet.damage);
        }
    }

    private void Update()
    {
        //speed = agent.velocity.magnitude;
        //
        //Debug.Log(gameObject.name +  "         :    �������� �������: " + speed);

        

        // ���� ������ �������� ����� ����� �������, �������� ������� �����
       

    }

    void FixedUpdate()
    {
        if (isBomb)
        {
            GameObject _bomb = Instantiate(bomb, transform.position, transform.rotation);
        }

        if (isRocket)
        {
            GetComponent<FireEnemyRocket>().enabled = true;
        }
        //���� true, �� ���� ������ �������� � ������
        //if (enemyRage)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.fixedDeltaTime);
        //    transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x) * Mathf.Rad2Deg - 90);
        //}

        //��������� ����� ������� � ������
        if (player != null)
        {
             dist = Vector3.Distance(player.transform.position, transform.position);
                      
            //���� ��������� ������ 7, �� ��������� �� ������
            if (dist <= 7f)
                {
                    agent.SetDestination(player.transform.position);
                    transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x) * Mathf.Rad2Deg - 90);
                }
                //����� ������� � ����� ��������������
                else
                {
                    agent.SetDestination(spawnPoints[randomSpawn].transform.position);
                    transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(spawnPoints[randomSpawn].transform.position.y - transform.position.y, spawnPoints[randomSpawn].transform.position.x - transform.position.x) * Mathf.Rad2Deg - 90);
                }
        }

        if (Vector2.Distance(transform.position, spawnPoints[randomSpawn].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpawn = Random.Range(0, spawnPoints.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.fixedDeltaTime;
            }
        }

        speed = agent.velocity.magnitude;
        speedTimer += Time.fixedDeltaTime;

        if (speedTimer > speedTimerLimit)
        {
            if (speed < 0.2f)
            {
                randomSpawn = Random.Range(0, spawnPoints.Length);
                agent.SetDestination(spawnPoints[randomSpawn].transform.position);
            }


        }

    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            if (GameManagers.isCoins)
            {
                if (GameManagers.isCombo)
                {
                    coinValue = coinValue * 2;
                    GameObject points = Instantiate(FloatingPointsCombo, transform.position, Quaternion.identity) as GameObject;
                    points.transform.GetChild(0).GetComponent<TextMeshPro>().text = coinValue.ToString();

                }
                else
                {
                    GameObject points = Instantiate(FloatingPoints, transform.position, Quaternion.identity) as GameObject;
                    points.transform.GetChild(0).GetComponent<TextMeshPro>().text = coinValue.ToString();

                }
            }
            AudioManager.instance.Play("EnemyDie");
            GameManagers.isCombo = true;
            Die();
        }
    }


    private void Die()
    {
        /*comboCounter++;
        int totalScore = comboCounter * scorePerKill;
        Debug.Log("�����: " + comboCounter + ", ����: " + totalScore);*/


        //Debug.Log("����� ��������!");
        if (GameManagers.isCoins)
        {
            GameManagers.instance.ChangeScore(coinValue);
        }
        
        Destroy(gameObject);
        GameManagers.instance.MinusCount(1);
        //GameManagers.instance.MinusEnemy(1);
        GameManagers.instance.CountEnemy();

        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.3f);

        for (int i = 0; i < objBonus.Length; i++)
        {
            if (Random.value < dropChance[i] / 100f)
            {
                Instantiate(objBonus[i], transform.position, Quaternion.identity);
            }
        }


        //PlayerPrefs.SetInt("money", GameManagers.score);
        //PlayerPrefs.Save();
    }

    void SetDestination (GameObject target)
    {
        var agentDrift = 0.0001f;
        var driftPos = target.transform.position + (Vector3)(agentDrift * Random.insideUnitCircle);
        agent.SetDestination(driftPos);
    }

}
