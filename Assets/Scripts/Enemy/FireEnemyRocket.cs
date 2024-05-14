using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnemyRocket : MonoBehaviour
{
    public GameObject rocketPrefab;
    public GameObject[] shootPoints = new GameObject[2];
    public float timeBetweenSpawns;
    float nextSpawnTime;
    float dist;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        //вычисляем дистанцию до игрока
        if (player != null)
        {
            dist = Vector3.Distance(player.transform.position, transform.position);
        }

        //если дистанция меньше 15
        if (dist <= 15f)
        {
            if (Time.time > nextSpawnTime)
            {
                GameObject bullet1 = Instantiate(rocketPrefab, shootPoints[0].transform.position, transform.rotation);
                GameObject bullet2 = Instantiate(rocketPrefab, shootPoints[1].transform.position, transform.rotation);
                Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
                Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
                rb1.AddForce(shootPoints[0].transform.right * 3, ForceMode2D.Impulse);
                rb2.AddForce(-shootPoints[1].transform.right * 3, ForceMode2D.Impulse);
                AudioManager.instance.Play("StartRocket");


                // GameObject rocket1 = Instantiate(rocketPrefab, shootPoints[0].transform.position, transform.rotation);
                // GameObject rocket2 = Instantiate(rocketPrefab, shootPoints[1].transform.position, transform.rotation);
                nextSpawnTime = Time.time + Random.Range(3f, 5f);
            }
        }
    }
}
