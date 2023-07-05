using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public GameObject[] boss;
    float maxX, minX, maxY, minY;
    static bool _isBoss;
    //public int countBoss;

    [Header("Спаун босса после n кол-во врагов")]
    public int afterSpawnBoss;

    public static SpawnBoss instance;

    public static bool IsBoss
    {
        get { return _isBoss; }
        set { _isBoss = value; }
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
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(transform.position, new Vector2(20, 40));
    }

    private void Update()
    {
        //Debug.Log(GameManagers.countEnemy +" из "+ afterSpawnBoss);
        //после
        if (GameManagers.countEnemy == afterSpawnBoss)
        {
            if (_isBoss == true)
            {
                _spawnBoss();
            }
            
        }
    }


    private void _spawnBoss()
    {
        for (int i = 0; i < boss.Length; i++)
        {
            if (boss[i].name == "Boss1")
            {
                AudioManager.instance.Play("MusicBoss1");
            }

            if (boss[i].name == "Boss2")
            {
                AudioManager.instance.Play("MusicBoss2");
            }

            if (boss[i].name == "Boss3")
            {
                AudioManager.instance.Play("MusicBoss3");
            }

            AudioManager.instance.Play("SpawnBoss");
            
            Vector3 spawmPos = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), transform.position.z);
            Instantiate(boss[i], spawmPos, Quaternion.identity);
        }
        _isBoss = false;

    }
}
