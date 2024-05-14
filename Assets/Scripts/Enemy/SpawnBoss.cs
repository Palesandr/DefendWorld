using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public GameObject boss;
    public GameObject SpawnZone;
    float maxX, minX, maxY, minY;
    static bool _isBoss;

    //public int countBoss;

    [Header("Спаун босса после n кол-во врагов")]
    static int _afterSpawnBoss;

    public static SpawnBoss instance;

    public static bool IsBoss
    {
        get { return _isBoss; }
        set { _isBoss = value; }
    }

    public static int afterSpawnBoss
    {
        get { return _afterSpawnBoss; }
        set { _afterSpawnBoss = value; }
    }

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        maxX = transform.position.x + transform.localScale.x / 2;
        minX = transform.position.x - transform.localScale.x / 2;

        maxY = transform.position.y + transform.localScale.y / 2;
        minY = transform.position.y - transform.localScale.y / 2;
        IsBoss = false;

        afterSpawnBoss = 50;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(transform.position, new Vector2(20, 40));
    }

    private void Update()
    {
        //Debug.Log(GameManagers.countEnemy +" из "+ afterSpawnBoss);
        //Debug.Log("_isBoss: " + IsBoss);
        //после
        if (GameManagers.countEnemy == afterSpawnBoss)
        {
            if (IsBoss == true)
            {  
                _spawnBoss();
                //SpawnZone.SetActive(false);
            }
            
        }
    }


    private void _spawnBoss()
    {
      
        //for (int i = 0; i < boss.Length; i++)
        //{
            //Debug.Log("Имя босса: "+ boss[i].name);

            if (boss.name == "Boss1")
            {
                //Debug.Log("Param 11");
                AudioManager.instance.Play("MusicBoss4");
                //Debug.Log("Param 12");
            }

            if (boss.name == "Boss2")
            {
                //Debug.Log("Param 2");
                AudioManager.instance.Play("MusicBoss2");
            }

            if (boss.name == "Boss3")
            {
                //Debug.Log("Param 3");
                AudioManager.instance.Play("MusicBoss5");
            }

            AudioManager.instance.Play("SpawnBoss");

            Vector3 spawmPos = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), transform.position.z);
            Instantiate(boss, spawmPos, Quaternion.identity);

            //Debug.Log("Param 4");
        //}
        IsBoss = false;
        GameManagers.isCoins = false;
    }
}
