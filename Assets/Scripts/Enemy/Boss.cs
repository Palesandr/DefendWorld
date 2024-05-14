using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public static int health;
    public static int maxHP;
    public int coinValue;
    public GameObject deathEffect; //������ ������
    public int timeOffSheild;
    float nextSpawnTime = 10f;
    bool onShield = true;
    public GameObject shield;
    Transform player;
    float dist;
    public int damage; //���� �� �������
    public int speed;
    //public GameObject[] shootDrons = new GameObject[2];
    //public GameObject prefDron;
    //public Transform target;     // ������, �� ������� ������
    [Header("���������� ����� ���������")]
    public float distance = 8f;  // �������� ���������� ����� ���������
    //public GameObject scorePanel;
    //public GameObject gameMenu;
    public Transform[] spawnPoints; //����� ��������������
    int randomSpawn; //������ ����� ������
    float waitTime;
    public float startWaitTime;
    public NavMeshAgent agent;
    //public ParticleSystem particleSystemDie;
    public string targetTag = "BonusHealth"; // ����� �����, � �������� ����� ���������
    public Transform target; // ������� ��������� ������
    public int LimitHealth;
    GameObject[] targets;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //scorePanel = GameObject.Find("ScoreMenu");
        //gameMenu = GameObject.Find("Game");

        switch (SpawnBoss.instance.boss.name)
        {
            case "Boss1":
                health = maxHP = 80;
                BossSheild.shieldHealth = 50;
                break;
            case "Boss2":
                health = maxHP = 100;
                BossSheild.shieldHealth = 70;
                break;
            case "Boss3":
                health = maxHP = 150; //150
                BossSheild.shieldHealth = 80; //80
                break;
            default:
                break;
        }

        PorogHealth(health);

        //������ ������ ����� ��� ��������������
        GameObject[] _obj = GameObject.FindGameObjectsWithTag("SpawnPoints");
        spawnPoints = new Transform[_obj.Length];
        for (int i = 0; i < spawnPoints.Length; i++)
            spawnPoints[i] = _obj[i].GetComponent<Transform>();

        //������ ��������� ����� ��� ��������������
        randomSpawn = UnityEngine.Random.Range(0, spawnPoints.Length);
        waitTime = startWaitTime;

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerController player = hitInfo.GetComponent<PlayerController>();
        Shield shield = hitInfo.GetComponent<Shield>();

        if (player != null)
        {
            AudioManager.instance.Play("EnemyDie");
            player.TakeDamage(damage);
            //Destroy(gameObject);
            //GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            //Destroy(effect, 0.3f);
        }

        if (shield != null)
        {
            AudioManager.instance.Play("EnemyDie");
            shield.TakeDamage(damage);
            //GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            //Destroy(effect, 0.3f);
           // Destroy(gameObject);

            //Debug.Log(EnemyBullet.damage);
        }

        BonusHealth bonusHealth = hitInfo.GetComponent<BonusHealth>();


        if (gameObject != null)
        {
            if (bonusHealth != null)
            {
                if (health < maxHP)
                {
                    //Debug.Log("upHealth:   " + bonusHealth.upHealth);
                    health += bonusHealth.upHealthBoss;
                }
            }
        }

    }

    private void Update()
    {
        

        if (shield != null)
        {
            if (Time.time > nextSpawnTime)
            {
                if (onShield == true)
                {
                    shield.SetActive(false);
                    onShield = false;
                    nextSpawnTime = Time.time + 10f;
                }
                else
                {
                    shield.SetActive(true);
                    onShield = true;
                    nextSpawnTime = Time.time + 10f;
                }
            }
        }

        //

        /*if (health <= LimitHealth)
        {


            if (target != null)
            {
                FindNearestTarget();
                Vector2 direction = target.position - transform.position;
            }
        }*/
    }

    // h - ���� �����, p - ������� �� h,  l - �����
    int PorogHealth(int h)
    {
        
        float b = h * 0.6f; //������� �� ������ �����
        LimitHealth = Convert.ToInt32(Math.Round(h - b));
        return LimitHealth;

        /*for (int i = h; i > Convert.ToInt32(h); i--)
        {
            if (i <= LimitHealth)
            {
                return LimitHealth;
            }
            
        }*/
    }

    private void FixedUpdate()
    {
        //targets = GameObject.FindGameObjectsWithTag(targetTag);

        if (player != null)
        {


            //���� ����� ������ ������, �� ��������� � ������ �����
            if (health <= LimitHealth)
            {
                FindNearestTarget();
                if (target != null)
                {
                    agent.speed = 10f;
                    agent.SetDestination(target.transform.position);
                }

                else
                {
                    agent.speed = 6f;
                    MoveBoss();
                }
            }
            else
            {
                agent.speed = 6f;
                MoveBoss();
            }
        }
    }


    void MoveBoss()
    {
        Vector3 direction = transform.position - player.position;

        dist = Vector3.Distance(player.position, transform.position);

        //transform.RotateAround(player.position, Vector3.forward, 20 * Time.deltaTime);
        //������� �� ������, ���� ���������� ������ 13
        if (dist <= 13f)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.fixedDeltaTime);
            transform.RotateAround(player.position, Vector3.forward, 40 * Time.fixedDeltaTime);
        }
        else
        {
            agent.SetDestination(spawnPoints[randomSpawn].transform.position);
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(spawnPoints[randomSpawn].transform.position.y - transform.position.y, spawnPoints[randomSpawn].transform.position.x - transform.position.x) * Mathf.Rad2Deg - 90);
        }

        //������ �� ������� � ���������� 17
        if (dist <= 17f)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(player.position.y - transform.position.y, player.position.x - transform.position.x) * Mathf.Rad2Deg - 90);
        }

        //������ ���������� �� ������ �� 8
        if (dist <= 8f)
        {
            if (direction.magnitude < distance)
            {
                // ���������� ������ �� ������ ���������� �� ����
                transform.position = player.position + direction.normalized * distance;
                //transform.RotateAround(player.position, Vector3.forward, 20 * Time.fixedDeltaTime);
            }
        }

        //��������������
        if (Vector2.Distance(transform.position, spawnPoints[randomSpawn].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpawn = UnityEngine.Random.Range(0, spawnPoints.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.fixedDeltaTime;
            }
        }
    }



    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            AudioManager.instance.Play("EnemyDie");
            Die();

        }

        //Debug.Log("health: " + health);
    }

    private void Die()
    {
        switch (SpawnBoss.instance.boss.name)
        {
            case "Boss1": AudioManager.instance.Stop("MusicBoss4");
                break;
            case "Boss2": AudioManager.instance.Stop("MusicBoss2");
                break;
            case "Boss3": AudioManager.instance.Stop("MusicBoss5");
                break;
            default:
                break;
        }



        Destroy(gameObject);

        GameManagers.instance.ChangeScore(coinValue);
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);

        GameManagers.instance.ShowMenuAfterDieBoss(true);
    }

    private void FindNearestTarget()
    {
        targets = GameObject.FindGameObjectsWithTag(targetTag); //������ �������� � ����� "BonusShield"
        float closestDistance = Mathf.Infinity;
        Transform closestTarget = null;

        foreach (GameObject targetObject in targets)
        {
            float distance = Vector2.Distance(transform.position, targetObject.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestTarget = targetObject.transform;
            }
        }

        target = closestTarget;
    }

}



