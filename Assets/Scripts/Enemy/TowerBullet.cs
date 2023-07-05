using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerBullet : MonoBehaviour
{
    public GameObject[] hitEffect = new GameObject[5];
    int rand;
    public int damage;
    public GameObject damageEffect;
    

    private void Update()
    {
        if (gameObject != null)
        {
            Destroy(gameObject, 5f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rand = Random.Range(0, hitEffect.Length);
        //Instantiate(hitEffect, transform.position, Quaternion.identity);
        GameObject effect = Instantiate(hitEffect[rand], transform.position, Quaternion.identity);
        Destroy(effect, 0.2f);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerController player = hitInfo.GetComponent<PlayerController>();
        Shield shield1 = hitInfo.GetComponent<Shield>();
        rand = Random.Range(0, hitEffect.Length);

        //Debug.Log(hitInfo.name);

        if (player != null)
        {
            //Debug.Log(hitInfo.name);
            player.TakeDamage(damage);
            GameObject effect = Instantiate(hitEffect[rand], transform.position, Quaternion.identity);
            Destroy(effect, 0.2f);
            Destroy(gameObject);
        }

        if (shield1 != null)
        {
            //Debug.Log(damage);
            shield1.TakeDamage(damage);
            GameObject effect = Instantiate(hitEffect[rand], transform.position, Quaternion.identity);
            Destroy(effect, 0.2f);
            Destroy(gameObject);
        }
    }

    void DestroyBullet()
    {
        Destroy(this.gameObject);
    }

}
