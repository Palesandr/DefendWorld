using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire2 : MonoBehaviour
{
    public GameObject bulletPrefab;
    GameObject bullet1, bullet2, bullet3, bullet4, bullet5, bullet6;
    Rigidbody2D rb1, rb2, rb3, rb4, rb5, rb6;
    public float bulletForce;
    public GameObject[] shootPoints = new GameObject[6];



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bullet1 = Instantiate(bulletPrefab, shootPoints[0].transform.position, transform.rotation);
            Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
            rb1.AddForce(shootPoints[0].transform.up * bulletForce, ForceMode2D.Impulse);

            bullet2 = Instantiate(bulletPrefab, shootPoints[1].transform.position, transform.rotation);
            Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
            rb2.AddForce(shootPoints[1].transform.up * bulletForce, ForceMode2D.Impulse);

            bullet3 = Instantiate(bulletPrefab, shootPoints[2].transform.position, transform.rotation);
            Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
            rb3.AddForce(shootPoints[2].transform.right * bulletForce, ForceMode2D.Impulse);

            bullet4 = Instantiate(bulletPrefab, shootPoints[3].transform.position, transform.rotation);
            Rigidbody2D rb4 = bullet4.GetComponent<Rigidbody2D>();
            rb4.AddForce(-shootPoints[3].transform.right * bulletForce, ForceMode2D.Impulse);

            bullet5 = Instantiate(bulletPrefab, shootPoints[4].transform.position, transform.rotation);
            Rigidbody2D rb5 = bullet5.GetComponent<Rigidbody2D>();
            rb5.AddForce(-shootPoints[4].transform.up * bulletForce, ForceMode2D.Impulse);

            bullet6 = Instantiate(bulletPrefab, shootPoints[5].transform.position, transform.rotation);
            Rigidbody2D rb6 = bullet6.GetComponent<Rigidbody2D>();
            rb6.AddForce(-shootPoints[5].transform.up * bulletForce, ForceMode2D.Impulse);

            AudioManager.instance.Play("PlayerFire");
        }
    }
}
