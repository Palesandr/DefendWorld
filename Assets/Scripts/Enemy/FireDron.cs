using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDron : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletForce;

    public GameObject shootPoints;
    public float timeBetweenSpawns;
    float nextSpawnTime;
    GameObject player;
    float dist;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (player != null)
        {
            dist = Vector3.Distance(player.transform.position, transform.position);
        }



        if (dist <= 7f)
        {
            if (Time.time > nextSpawnTime)
            {
                GameObject bullet = Instantiate(bulletPrefab, shootPoints.transform.position, transform.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(shootPoints.transform.up * bulletForce, ForceMode2D.Impulse);
                AudioManager.instance.Play("EnemyFire3");
             }
               
                //nextSpawnTime = Time.time + timeBetweenSpawns;
                nextSpawnTime = Time.time + Random.Range(0.7f, 1.5f);
            
        }
    }
}
