using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRocket : MonoBehaviour
{
    public GameObject hitEffect;
    int rand;
    static int _rocketDamage = 3;
    public LayerMask whatIsSolid;

    public static int rocketDamage
    {
        get { return _rocketDamage; }
        set { _rocketDamage = value; }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        //Instantiate(hitEffect, transform.position, Quaternion.identity);
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.2f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerController player = hitInfo.GetComponent<PlayerController>();
        Shield shield = hitInfo.GetComponent<Shield>();


        if (player != null)
        {
            //Debug.Log(hitInfo.name);
            player.TakeDamage(rocketDamage);
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.2f);
            Destroy(gameObject);
        }

        if (shield != null)
        {
            //Debug.Log(hitInfo.name);
            shield.TakeDamage(rocketDamage);
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.2f);
            Destroy(gameObject);
        }
    }
}
