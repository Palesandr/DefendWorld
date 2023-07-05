using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRocket : MonoBehaviour
{
    public GameObject[] shootPoints = new GameObject[2];
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public GameObject enemy;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet1 = Instantiate(bulletPrefab, shootPoints[0].transform.position, transform.rotation);
            Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
            rb1.AddForce(shootPoints[0].transform.right * 3, ForceMode2D.Impulse);           
        }
    }

}
