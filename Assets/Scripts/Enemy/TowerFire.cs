using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    GameObject player;
    float dist; // дистанция до игрока
    public float timeBetweenSpawns;
    float nextSpawnTime;
    public GameObject shootPoint;
    public float bulletForce;
    public GameObject flashEffect;

    [Header("дистанция до игрока")]
    public float distValue;
    

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        EnemyBullet.damage = 3;

        //Debug.Log(flashEffect);
    }

    void Update()
    {
        if (player != null)
        {
            dist = Vector3.Distance(player.transform.position, transform.position);
        }



        if (dist <= distValue)
        {
            if (Time.time > nextSpawnTime)
            {
                GameObject _flashEffect = Instantiate(flashEffect, shootPoint.transform.position, shootPoint.transform.rotation);

                GameObject bullet = Instantiate(bulletPrefab, shootPoint.transform.position, transform.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(shootPoint.transform.up * bulletForce, ForceMode2D.Impulse);
                Destroy(_flashEffect, 0.15f);
                AudioManager.instance.Play("TowerFire");

                nextSpawnTime = Time.time + Random.Range(1f, 2f);
            }
        }
    }
}
