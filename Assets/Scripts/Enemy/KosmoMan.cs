using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KosmoMan : MonoBehaviour
{
    public GameObject player;
    public int health = 1;
    float dist;
    int coinValue = 1; //очки за уничтожение

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerController player = hitInfo.GetComponent<PlayerController>();
        Shield shield = hitInfo.GetComponent<Shield>();

        if (player != null)
        {
            AudioManager.instance.Play("EnemyDie");
            player.TakeDamage(1);
            Destroy(gameObject);
            //GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            //Destroy(effect, 0.3f);
        }

        if (shield != null)
        {
            AudioManager.instance.Play("EnemyDie");
            shield.TakeDamage(1);
            //GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
           // Destroy(effect, 0.3f);
            Destroy(gameObject);

            //Debug.Log(EnemyBullet.damage);
        }
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            dist = Vector3.Distance(player.transform.position, transform.position);

            if (dist <= 10f)
            {
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x) * Mathf.Rad2Deg - 90);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            AudioManager.instance.Play("EnemyDie");
            Die();
        }
    }

    private void Die()
    {
        GameManagers.instance.ChangeScore(coinValue);
        Destroy(gameObject);
    }

}
