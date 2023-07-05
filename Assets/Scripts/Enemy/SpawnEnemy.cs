using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    
    public GameObject[] enemy = new GameObject[4];
    float maxX, minX, maxY, minY;
    float nextSpawnTime;
    public float beginTime;
    public float endTime;
    int _countEnemy; //кол-во одновременно активных врагов
    int _currentEnemyLevel; //общее кол-во врагов, сколько должны появиться
    int _allEnemyLevel;
    GameManagers gameManagers;
    public GameObject[] spawnEffect = new GameObject[4]; //эффект спауна

    private void Start()
    {

        maxX = transform.position.x + transform.localScale.x / 2;
        minX = transform.position.x - transform.localScale.x / 2;

        maxY = transform.position.y + transform.localScale.y / 2;
        minY = transform.position.y - transform.localScale.y / 2;

        GameObject go = GameObject.Find("GameManager");
        gameManagers = go.GetComponent<GameManagers>();

        _allEnemyLevel = gameManagers.countEnemyLevel;
        
    }

    private void Update()
    {   
        Spawn();
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector2(15, 15));
    }

    private void Spawn()
    {
        
        int r;
        r = Random.Range(0, 4);

        _countEnemy = GameManagers.instance.countEnemySpawn;
        //_currentEnemyLevel = gameManagers.countEnemyLevel;

        //Debug.Log(Mathf.Round(_countEnemyLevel / 2));

        if (Time.time > nextSpawnTime)
        {
            //спаун если врагов меньше 15
            if (_countEnemy < 15)
            {

                Vector3 spawmPos = new Vector3(Random.Range(minX, maxX),  Random.Range(minY, maxY), transform.position.z);
                Instantiate(enemy[r], spawmPos, Quaternion.identity);
                nextSpawnTime = Time.time + Random.Range(beginTime, endTime);
                GameManagers.instance.PlusCount(1);

                //Debug.Log(GameManagers.countEnemySpawn);
            }

            switch (enemy[r].name)
            {
                case "Enemy1":
                    EnemyBullet.damage = Random.Range(1,3);
                    break;
                case "Enemy2":
                    EnemyBullet.damage = Random.Range(1, 3); 
                    break;
                case "Enemy3":
                    EnemyBullet.damage = Random.Range(2, 3); 
                    break;
                case "Enemy4":
                    EnemyBullet.damage = Random.Range(2, 4); 
                    break;
                case "Enemy5":
                    EnemyBullet.damage = Random.Range(3, 5); 
                    break;
                case "Enemy6":
                    EnemyBullet.damage = Random.Range(3, 5);
                    break;
                case "Enemy7":
                    EnemyBullet.damage = Random.Range(3, 6);
                    break;
                case "Enemy8":
                    EnemyBullet.damage = Random.Range(3, 5);
                    break;
                case "Enemy9":
                    EnemyBullet.damage = Random.Range(2, 5);
                    EnemyRocket.rocketDamage = Random.Range(3, 8);
                    break;
                default:
                    break;
            }


        }
    }

}


