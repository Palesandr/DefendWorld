using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBoss : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletForce;

    bool shootBool = true;
    public GameObject[] shootPoints = new GameObject[2];
    public float timeBetweenSpawns;
    float nextSpawnTime;
    GameObject player;
    float dist;


    private void Start()     
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player != null)
        {
            dist = Vector3.Distance(player.transform.position, transform.position);
        }



        if (dist <= 10f)
        {
            if (Time.time > nextSpawnTime)
            {
                if (shootBool)
                {
                    GameObject bullet = Instantiate(bulletPrefab, shootPoints[0].transform.position, transform.rotation);
                    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                    rb.AddForce(shootPoints[0].transform.up * bulletForce, ForceMode2D.Impulse);
                    shootBool = false;
                    AudioManager.instance.Play("EnemyFire3");
                }
                else
                {
                    GameObject bullet = Instantiate(bulletPrefab, shootPoints[1].transform.position, transform.rotation);
                    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                    rb.AddForce(shootPoints[1].transform.up * bulletForce, ForceMode2D.Impulse);
                    shootBool = true;
                    AudioManager.instance.Play("EnemyFire3");
                }
                //nextSpawnTime = Time.time + timeBetweenSpawns;
                nextSpawnTime = Time.time + Random.Range(0.2f, 0.4f);
            }
        }
    }
}

