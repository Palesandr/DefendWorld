using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombWave : MonoBehaviour
{
    public int damageExplosion = 10; //урон от взрыва
    public GameObject PS_expBombWave;
    public CircleCollider2D Collider1;

    public float lifeTime = 3f; //время взрыва
    public float colTime = 2.8f; //время включения коллайдера
    private float timer = 0f;
    //public Component[] circleCollider2D;
    public LayerMask whatAreAttack;



    private void Start()
    {
       //Collider1.enabled = false;
        // circleCollider2D = GetComponentsInChildren<CircleCollider2D>();
    }

    void Update()
    {
        timer += Time.deltaTime; 
        //timer2 += Time.deltaTime;

        if (timer >= colTime)
        {
            
            /*foreach (CircleCollider2D circle in circleCollider2D)
                circle.enabled = true;*/
            
           Collider1.enabled = true;


        }


        if (timer >= lifeTime)
        {

            AudioManager.instance.Play("ExplosionBombWave");
            Explode();
            
        }
    }

    void Explode()
    {
        GameObject ExpBombWave = Instantiate(PS_expBombWave, transform.position, Quaternion.identity); 
        Destroy(gameObject);
        Destroy(ExpBombWave, 5f);
    }

    /*private void Start()
    {
        Debug.Log("снаряд создан");
        StartCoroutine(TimeExpBombWave());
    }*/


    /*IEnumerator TimeExpBombWave()
    {
       yield return new WaitForSeconds(3f);
       Debug.Log("ща будет взрыв");
       PS_expBombWave.Play();
    }*/

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        CheckForEnemy();

        Enemy enemy = hitInfo.GetComponent<Enemy>();
        KosmoMan kosmoMan = hitInfo.GetComponent<KosmoMan>();
        Boss boss = hitInfo.GetComponent<Boss>();
        BossSheild bossSheild = hitInfo.GetComponent<BossSheild>();
        Dron dron = hitInfo.GetComponent<Dron>();
        EnemyBomb enemyBomb = hitInfo.GetComponent<EnemyBomb>();

        //rand = Random.Range(0, hitEffect.Length);

        if (enemy != null)
        {
            //Debug.Log(hitInfo.name);
            enemy.TakeDamage(damageExplosion);
            GameObject ExpBombWave = Instantiate(PS_expBombWave, transform.position, Quaternion.identity);

            Destroy(ExpBombWave, 2f);
            AudioManager.instance.Play("EnemyDamage");
            Destroy(gameObject);
        }

        if (kosmoMan != null)
        {
            //Debug.Log(hitInfo.name);
            kosmoMan.TakeDamage(damageExplosion);
            GameObject ExpBombWave = Instantiate(PS_expBombWave, transform.position, Quaternion.identity);
 
            Destroy(ExpBombWave, 2f);
            Destroy(gameObject);
        }

        if (boss != null)
        {
            //Debug.Log(hitInfo.name);
            boss.TakeDamage(damageExplosion);
            GameObject ExpBombWave = Instantiate(PS_expBombWave, transform.position, Quaternion.identity);
 
            Destroy(ExpBombWave, 2f);
            AudioManager.instance.Play("EnemyDamage");
            Destroy(gameObject);
        }

        if (bossSheild != null)
        {
            AudioManager.instance.Play("ShieldShoot");
            //Debug.Log(damage);
            bossSheild.TakeDamage(damageExplosion);
            GameObject ExpBombWave = Instantiate(PS_expBombWave, transform.position, Quaternion.identity);

            Destroy(ExpBombWave, 2f);
            Destroy(gameObject);
        }

        if (dron != null)
        {
            AudioManager.instance.Play("ShieldShoot");
            //Debug.Log(damage);
            dron.TakeDamage(damageExplosion);
            GameObject ExpBombWave = Instantiate(PS_expBombWave, transform.position, Quaternion.identity);

            Destroy(ExpBombWave, 2f);
            Destroy(gameObject);
        } 
        
        if (enemyBomb != null)
        {
            AudioManager.instance.Play("Bomb");
            //Debug.Log(damage);
            //dron.TakeDamage(damageExplosion);
            GameObject ExpBombWave = Instantiate(PS_expBombWave, transform.position, Quaternion.identity);

            Destroy(ExpBombWave, 2f);
            Destroy(enemyBomb);
            Destroy(gameObject);
        }
    }

    /*void OnDrawGizmos()
    {
        if (Collider1.enabled == true)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, 3);
        }

    }*/

    //вклчаем коллайдер через 3 сек
    /*private IEnumerator EnableCollider()
    {
        yield return new WaitForSeconds(1f);
        foreach (CircleCollider2D circle in circleCollider2D)
            circle.enabled = true;
    }*/

    void CheckForEnemy()
    {
        Collider2D[] coll = Physics2D.OverlapCircleAll(transform.position, 3f, whatAreAttack);
        foreach (Collider2D c in coll)
        {
            if (c.GetComponent<Enemy>())
            {
                c.GetComponent<Enemy>().TakeDamage(damageExplosion);
            }
        }
    }
}
