using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disk : MonoBehaviour
{
    public int damage = 3;
    GameObject _player;
    Rigidbody2D rb;
    bool b;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player"); 
        rb = _player.GetComponent<Rigidbody2D>(); 
    }


    private void Update()
    {
        if (b)
        {
            rb.AddForce(-_player.transform.up * 10, ForceMode2D.Impulse);
            //rb.AddForce((transform.position - _player.transform.position).normalized * 10, ForceMode2D.Impulse);
            b = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //здесь делаем то, когда входим в зону бомбы
        PlayerController player = hitInfo.GetComponent<PlayerController>();
        Shield shield = hitInfo.GetComponent<Shield>();

        if (player != null)
        {
            //Debug.Log(hitInfo.name);
            player.TakeDamage(damage);
            b = true;
            //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            //Destroy(effect, 0.2f);

            
        }

        if (shield != null)
        {
            //Debug.Log(hitInfo.name);
            shield.TakeDamage(damage);
            b = true;
            //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            //Destroy(effect, 0.2f);

        }

    }
}
