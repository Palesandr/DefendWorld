using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireKosmoMan : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletForce;
    public GameObject shootPoints;
    float nextSpawnTime;
    float dist;
    public GameObject player;


    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (player != null)
        {
            dist = Vector3.Distance(player.transform.position, transform.position);
        }

        if (dist <= 9f)
        {
            if (Time.time > nextSpawnTime)
            {
                GameObject bullet = Instantiate(bulletPrefab, shootPoints.transform.position, transform.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(shootPoints.transform.up * bulletForce, ForceMode2D.Impulse);

                nextSpawnTime = Time.time + 0.5f;
            }
        }
    }
}
