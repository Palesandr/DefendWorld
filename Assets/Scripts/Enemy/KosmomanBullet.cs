using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KosmomanBullet : MonoBehaviour
{
    public float timeDestroy; //время уничтожения снаряда
    public int damage = 1; //урон от снаряда
   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerController player = hitInfo.GetComponent<PlayerController>();
        Shield shield = hitInfo.GetComponent<Shield>();


        if (player != null)
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
        }

        if (shield != null)
        {
            AudioManager.instance.Play("ShieldShoot");
            shield.TakeDamage(damage);
            Destroy(gameObject);
        }

    }


}
