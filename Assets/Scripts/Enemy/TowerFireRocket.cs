using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFireRocket : MonoBehaviour
{
    public GameObject rocketPrefab;
    public GameObject shootPoints;
    GameObject player;
    float dist;
    public float timeBetweenSpawns;
    float nextSpawnTime;


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

                GameObject bullet = Instantiate(rocketPrefab, shootPoints.transform.position, transform.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(shootPoints.transform.up * 3, ForceMode2D.Impulse);
                AudioManager.instance.Play("StartRocket");


                // GameObject rocket1 = Instantiate(rocketPrefab, shootPoints[0].transform.position, transform.rotation);
                // GameObject rocket2 = Instantiate(rocketPrefab, shootPoints[1].transform.position, transform.rotation);
                nextSpawnTime = Time.time + Random.Range(3f, 5f);
            }
        }
    }
}
