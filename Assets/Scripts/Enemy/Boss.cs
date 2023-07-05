using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public int health = 2;
    public int coinValue;
    public GameObject deathEffect; //эффект смерти
    public int timeOffSheild;
    float nextSpawnTime = 10f;
    bool onShield = true;
    public GameObject shield;
    Transform player;
    float dist;
    public int damage; //урон от корабля
    public int speed;
    //public GameObject[] shootDrons = new GameObject[2];
    //public GameObject prefDron;
    //public Transform target;     // объект, за которым следим
    [Header("расстояние между объектами")]
    public float distance = 8f;  // желаемое расстояние между объектами
    //public GameObject scorePanel;
    //public GameObject gameMenu;
    public Transform[] spawnPoints; //точки патрулирования
    int randomSpawn; //рнадом точек спауна
    float waitTime;
    public float startWaitTime;
    public NavMeshAgent agent;
    //public ParticleSystem particleSystemDie;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //scorePanel = GameObject.Find("ScoreMenu");
        //gameMenu = GameObject.Find("Game");

        //создаём массив точек для патрулирования
        GameObject[] _obj = GameObject.FindGameObjectsWithTag("SpawnPoints");
        spawnPoints = new Transform[_obj.Length];
        for (int i = 0; i < spawnPoints.Length; i++)
            spawnPoints[i] = _obj[i].GetComponent<Transform>();

        //первая рандомная точка для патрулирования
        randomSpawn = Random.Range(0, spawnPoints.Length);
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
            Destroy(gameObject);
            //GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            //Destroy(effect, 0.3f);
        }

        if (shield != null)
        {
            AudioManager.instance.Play("EnemyDie");
            shield.TakeDamage(damage);
            //GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            //Destroy(effect, 0.3f);
            Destroy(gameObject);

            //Debug.Log(EnemyBullet.damage);
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
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            Vector3 direction = transform.position - player.position;

            dist = Vector3.Distance(player.position, transform.position);

            //transform.RotateAround(player.position, Vector3.forward, 20 * Time.deltaTime);
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
            
            if (dist <= 17f)
            {
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(player.position.y - transform.position.y, player.position.x - transform.position.x) * Mathf.Rad2Deg - 90);
            }

            if (dist <= 8f)
            {
                if (direction.magnitude < distance)
                {
                    // перемещаем объект на нужное расстояние от цели
                    transform.position = player.position + direction.normalized * distance;
                    //transform.RotateAround(player.position, Vector3.forward, 20 * Time.fixedDeltaTime);
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
        }
    }


    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //particleSystemDie.Play();
        for (int i = 0; i < SpawnBoss.instance.boss.Length; i++)
        {
            if (SpawnBoss.instance.boss[i].name == "Boss1")
            {
                AudioManager.instance.Stop("MusicBoss1");
            }

            if (SpawnBoss.instance.boss[i].name == "Boss2")
            {
                AudioManager.instance.Stop("MusicBoss2");
            }

            if (SpawnBoss.instance.boss[i].name == "Boss3")
            {
                AudioManager.instance.Stop("MusicBoss3");
            }
        }

        Destroy(gameObject);

        GameManagers.instance.ChangeScore(coinValue);

        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
       
        Destroy(effect, 0.5f);

        GameManagers.instance.ShowMenuAfterDieBoss(true);
    }


}
