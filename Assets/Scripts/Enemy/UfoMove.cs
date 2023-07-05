using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoMove : MonoBehaviour
{
    public float speed = 5f;
    GameObject player;
    public int damage;
    public Transform _player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        /*ar heading = transform.position - _player.position;

        float dist = Vector3.Distance(player.transform.position, transform.position);

        if (dist <= 7f)
        {
            transform.position = Vector2.MoveTowards(transform.position - _player.position, _player.position, speed * Time.fixedDeltaTime);
            //transform.RotateAround(_player.position, Vector3.back, 90 * Time.deltaTime);
        }
        //transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.fixedDeltaTime);
        //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x) * Mathf.Rad2Deg - 90);
        //transform.RotateAround(_player.position, Vector3.back, 90 * Time.deltaTime);

        Debug.Log("heading: " + heading);
        Debug.Log("dist: " + dist);*/




    }

   /* private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerController player = hitInfo.GetComponent<PlayerController>();
        Shield shield = hitInfo.GetComponent<Shield>();

        if (player != null)
        {
            AudioManager.instance.Play("EnemyDie");
            player.TakeDamage(EnemyBullet.damage);
            Destroy(gameObject);
            //GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            //Destroy(effect, 0.3f);
        }

        if (shield != null)
        {
            AudioManager.instance.Play("EnemyDie");
            shield.TakeDamage(EnemyBullet.damage);
            //GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            //Destroy(effect, 0.3f);
            Destroy(gameObject);
        }
    }*/
}
