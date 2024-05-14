using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
using UnityEngine.AI;


public class EnemyMove : MonoBehaviour
{
    //public float speed; //скорость
    GameObject player; //плеер
    public int health = 2; //жизнь
    public int coinValue = 0; //очки за уничтожение
    float dist;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerController player = hitInfo.GetComponent<PlayerController>();
        Shield shield = hitInfo.GetComponent<Shield>();

        if (player != null)
        {
            player.TakeDamage(EnemyBullet.damage);
            Destroy(gameObject);
        }

        if (shield != null)
        {
            shield.TakeDamage(EnemyBullet.damage);
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        //если true, то враг всегда движется к игроку
        //if (enemyRage)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.fixedDeltaTime);
        //    transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x) * Mathf.Rad2Deg - 90);
        //}

        //дистанция между игроком и врагом
        if (player != null)
        {

                //если дистанция меньше 7, то двигаемся на плеера
                if (dist <= 7f)
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
        Destroy(gameObject);
    }

  
}
