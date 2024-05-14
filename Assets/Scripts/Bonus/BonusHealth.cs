using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusHealth : MonoBehaviour
{
    public int upHealth = 2;
    public int upHealthBoss = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController pc = collision.GetComponent<PlayerController>();
        Boss boss = collision.GetComponent<Boss>();

        if (pc != null)
        {
            if (PlayerController.health < PlayerController.maxHP)
            {
                AudioManager.instance.Play("HealthBonus");
                Destroy(gameObject);
            }
        } 
        
        if (boss != null)
        {
            if (Boss.health < Boss.maxHP)
            {
                AudioManager.instance.Play("HealthBonus");
                Destroy(gameObject);
            }
        }
    }
}
