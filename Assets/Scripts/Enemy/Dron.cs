using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dron : MonoBehaviour
{
    public int health = 1; //жизнь
    public int damage = 1; //урон от корабля
    public int coinValue = 1; //очки за уничтожение
    public int speed = 9;

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
        GameManagers.instance.ChangeScore(coinValue);
        Destroy(gameObject);
        //GameManagers.instance.MinusCount(1);
        //GameManagers.instance.MinusEnemy(1);
        GameManagers.instance.CountEnemy();

        //GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 0.3f);



        //PlayerPrefs.SetInt("money", GameManagers.score);
        //PlayerPrefs.Save();
    }
}
