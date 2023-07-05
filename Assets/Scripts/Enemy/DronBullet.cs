using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronBullet : MonoBehaviour
{
    public GameObject[] hitEffect = new GameObject[5];
    int rand;
    public int damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rand = Random.Range(0, hitEffect.Length);
        //Instantiate(hitEffect, transform.position, Quaternion.identity);
        GameObject effect = Instantiate(hitEffect[rand], transform.position, Quaternion.identity);
        Destroy(effect, 0.2f);
        Destroy(gameObject);

    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerController player = hitInfo.GetComponent<PlayerController>();
        Shield shield = hitInfo.GetComponent<Shield>();
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

        if (shield != null)
        {
            AudioManager.instance.Play("ShieldShoot");
            //Debug.Log(damage);
            shield.TakeDamage(damage);
            GameObject effect = Instantiate(hitEffect[rand], transform.position, Quaternion.identity);
            Destroy(effect, 0.2f);
            Destroy(gameObject);
        }
    }

}
