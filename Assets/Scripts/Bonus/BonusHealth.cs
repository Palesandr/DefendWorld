using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusHealth : MonoBehaviour
{
    public int upHealth = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController pc = collision.GetComponent<PlayerController>();

        if (pc != null)
        {
            if (PlayerController.health < PlayerController.maxHP)
            {
                AudioManager.instance.Play("HealthBonus");
                Destroy(gameObject);
            }
        }
    }
}
