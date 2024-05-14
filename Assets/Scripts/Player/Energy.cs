using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Energy : MonoBehaviour
{
    public GameObject[] hitEffect = new GameObject[5];
    public float timeDestroy; //время уничтожения снаряда
    public int damage = 1; //урон от снаряда
    int rand;

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        KosmoMan kosmoMan = hitInfo.GetComponent<KosmoMan>();
        Boss boss = hitInfo.GetComponent<Boss>();
        BossSheild bossSheild = hitInfo.GetComponent<BossSheild>();
        Dron dron = hitInfo.GetComponent<Dron>();

        rand = Random.Range(0, hitEffect.Length);

        if (enemy != null)
        {
            //Debug.Log(hitInfo.name);
            enemy.TakeDamage(Fire.energy);
            GameObject effect = Instantiate(hitEffect[rand], transform.position, Quaternion.identity);
            Destroy(effect, 0.15f);
            AudioManager.instance.Play("EnemyDamage");
            //Destroy(gameObject);
        }

        if (kosmoMan != null)
        {
            //Debug.Log(hitInfo.name);
            kosmoMan.TakeDamage(Fire.energy);
            GameObject effect = Instantiate(hitEffect[rand], transform.position, Quaternion.identity);
            Destroy(effect, 0.15f);
            //Destroy(gameObject);
        }

        if (boss != null)
        {
            //Debug.Log(hitInfo.name);
            boss.TakeDamage(Fire.energy);
            GameObject effect = Instantiate(hitEffect[rand], transform.position, Quaternion.identity);
            AudioManager.instance.Play("EnemyDamage");
            Destroy(effect, 0.15f);
            //Destroy(gameObject);
        }

        if (bossSheild != null)
        {
            AudioManager.instance.Play("ShieldShoot");
            //Debug.Log(damage);
            bossSheild.TakeDamage(Fire.energy);
            GameObject effect = Instantiate(hitEffect[rand], transform.position, Quaternion.identity);
            Destroy(effect, 0.2f);
            //Destroy(gameObject);
        }

        if (dron != null)
        {
            AudioManager.instance.Play("ShieldShoot");
            //Debug.Log(damage);
            dron.TakeDamage(Fire.energy);
            GameObject effect = Instantiate(hitEffect[rand], transform.position, Quaternion.identity);
            Destroy(effect, 0.2f);
            //Destroy(gameObject);
        } 
        
    }
}
