using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBomb : MonoBehaviour
{
    public int damage = 2;
    //GameObject _enemy;
    //float dist;
    public Component[] circleCollider2D;
    public GameObject hitBombEffect;

 
    void Update()
    {
        transform.Rotate(0, 0, 5f);
    }


    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        KosmoMan kosmoMan = hitInfo.GetComponent<KosmoMan>();
        Boss boss = hitInfo.GetComponent<Boss>();

        //rand = Random.Range(0, hitEffect.Length);

        if (enemy != null)
        {
            //Debug.Log(hitInfo.name);
            enemy.TakeDamage(damage);
            GameObject effect = Instantiate(hitBombEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.15f);
            Destroy(gameObject);
        }

        if (kosmoMan != null)
        {
            //Debug.Log(hitInfo.name);
            kosmoMan.TakeDamage(damage);
            GameObject effect = Instantiate(hitBombEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.15f);
            Destroy(gameObject);
        }

        if (boss != null)
        {
            //Debug.Log(hitInfo.name);
            boss.TakeDamage(damage);
            GameObject effect = Instantiate(hitBombEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.15f);
            Destroy(gameObject);
        }
    }

}
