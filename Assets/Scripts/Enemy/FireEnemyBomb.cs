using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnemyBomb : MonoBehaviour
{
    public GameObject bombPrefab;
    public GameObject shootPoint;
    public float timeBetweenSpawns;
    float nextSpawnTime;
    public float bulletForce = 0f;

    private void Update()
    {
        if (Time.time > nextSpawnTime)
        {

           GameObject bomm = Instantiate(bombPrefab, shootPoint.transform.position, transform.rotation);
           //Rigidbody2D rb = bomm.GetComponent<Rigidbody2D>();
           //rb.AddForce(shootPoint.transform.up * bulletForce, ForceMode2D.Impulse);
           //AudioManager.instance.Play("EnemyFire");

            //nextSpawnTime = Time.time + timeBetweenSpawns;
            nextSpawnTime = Time.time + Random.Range(3f, 5f);
        }
    }
}
