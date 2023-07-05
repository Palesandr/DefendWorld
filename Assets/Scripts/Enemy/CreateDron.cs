using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateDron : MonoBehaviour
{
    Transform player;
    public GameObject[] shootDrons = new GameObject[2];
    public GameObject prefDron;
    public int countDrons;
    float dist;
    public int dronsPerShot; // количество дронов в одной очереди
    public float timeBetweenShots; // время между выстрелами в очереди
    public float timeBetweenDrons; // время между выстрелами
    private float timer;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        InvokeRepeating("CreateObject", 0f, 5f);
    }

    private void Update()
    {
        
        //вычисляем дистанцию до игрока
        if (player != null)
        {
            dist = Vector3.Distance(player.transform.position, transform.position);
        }


    }


    void CreateObject()
    {
        if (dist <= 10f)
        {


            if (countDrons > 0)
            {
                GameObject bullet1 = Instantiate(prefDron, shootDrons[0].transform.position, transform.rotation);
                GameObject bullet2 = Instantiate(prefDron, shootDrons[1].transform.position, transform.rotation);
                Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
                Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
                rb1.AddForce(-shootDrons[0].transform.right * 3, ForceMode2D.Impulse);
                rb2.AddForce(shootDrons[1].transform.right * 3, ForceMode2D.Impulse);
                countDrons--;
            }
        }
    }

    private IEnumerator Shoot()
    {
        for (int i = 0; i < dronsPerShot; i++)
        {
            GameObject bullet = Instantiate(prefDron, transform.position, transform.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = transform.forward * 8;
            yield return new WaitForSeconds(timeBetweenDrons);
        }
    }

}


