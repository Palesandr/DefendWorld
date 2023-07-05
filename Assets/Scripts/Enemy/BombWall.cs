using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombWall : MonoBehaviour
{
    public int damage = 5;
    GameObject _player;
    float dist;
    //public GameObject hitEffect;
    Rigidbody2D rb;
    bool isDetectedBomb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("Player");
        isDetectedBomb = false;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {


        //здесь делаем то, когда входим в зону бомбы
        PlayerController player = hitInfo.GetComponent<PlayerController>();
        Shield shield = hitInfo.GetComponent<Shield>();
        Bullet bullet = hitInfo.GetComponent<Bullet>();

        if (player != null)
        {
            Debug.Log(hitInfo.name);
            player.TakeDamage(damage);
            //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            //Destroy(effect, 0.2f);
            Destroy(gameObject);
        }

        if (shield != null)
        {
            Debug.Log(hitInfo.name);
            shield.TakeDamage(damage);
            //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            //Destroy(effect, 0.2f);
            Destroy(gameObject);
        }

        if (bullet != null)
        {
            Debug.Log(hitInfo.name);
            //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            //Destroy(effect, 0.2f);
            Destroy(gameObject);
        }

    }

    private void FixedUpdate()
    {
        if (isDetectedBomb == true)
        {
            if (_player != null)
            {
                dist = Vector3.Distance(_player.transform.position, transform.position);


                if (dist < 5)
                {
                    transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, 7 * Time.fixedDeltaTime);
                }
            }
        }
    }

    private void Update()
    {
        if (isDetectedBomb == false)
        {
            FlyOffTheWall();
        }
    }

    void FlyOffTheWall()
    {
        int layerMask = LayerMask.GetMask("Player", "Shield");


        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), 7f, layerMask);

        if (hitInfo.collider != null)
        {
            switch (hitInfo.collider.name)
            {
                case "Shield":
                    rb.AddForce(transform.up * 6f, ForceMode2D.Impulse);
                    isDetectedBomb = true;
                    //Debug.Log(hitInfo.collider.name);
                    break;
                case "Player":
                    rb.AddForce(transform.up * 6f, ForceMode2D.Impulse);
                    isDetectedBomb = true;
                   // Debug.Log(hitInfo.collider.name);
                    break;
            }
        }

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.up) * 7f, Color.red);
    }

}
