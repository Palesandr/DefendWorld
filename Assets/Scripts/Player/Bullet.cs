using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //    public GameObject hitEffect;
    public GameObject[] hitEffect = new GameObject[5];
    public float timeDestroy; //время уничтожения снаряда
    public int damage = 1; //урон от снаряда
    public float distance;
    int rand;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        rand = Random.Range(0, hitEffect.Length);
        GameObject effect = Instantiate(hitEffect[rand], transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(effect, 0.15f);
    }

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
            enemy.TakeDamage(damage);
            GameObject effect = Instantiate(hitEffect[rand], transform.position, Quaternion.identity);
            Destroy(effect, 0.15f);
            AudioManager.instance.Play("EnemyDamage");
            Destroy(gameObject);
        }

        if (kosmoMan != null)
        {
            //Debug.Log(hitInfo.name);
            kosmoMan.TakeDamage(damage);
            GameObject effect = Instantiate(hitEffect[rand], transform.position, Quaternion.identity);
            Destroy(effect, 0.15f);
            Destroy(gameObject);
        }

        if (boss != null)
        {
            //Debug.Log(hitInfo.name);
            boss.TakeDamage(damage);
            GameObject effect = Instantiate(hitEffect[rand], transform.position, Quaternion.identity);
            Destroy(effect, 0.15f);
            Destroy(gameObject);
        }

        if (bossSheild != null)
        {
            AudioManager.instance.Play("ShieldShoot");
            //Debug.Log(damage);
            bossSheild.TakeDamage(damage);
            GameObject effect = Instantiate(hitEffect[rand], transform.position, Quaternion.identity);
            Destroy(effect, 0.2f);
            Destroy(gameObject);
        }

        if (dron != null)
        {
            AudioManager.instance.Play("ShieldShoot");
            //Debug.Log(damage);
            dron.TakeDamage(damage);
            GameObject effect = Instantiate(hitEffect[rand], transform.position, Quaternion.identity);
            Destroy(effect, 0.2f);
            Destroy(gameObject);
        }

    }
}
