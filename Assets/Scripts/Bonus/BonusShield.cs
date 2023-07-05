using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusShield : MonoBehaviour
{
    public int upShield = 2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Shield sh = collision.GetComponent<Shield>();

        if (sh != null)
        {
            if (Shield.shieldHealth < Shield.maxHP)
            {
                AudioManager.instance.Play("ShieldBonus");
                Destroy(gameObject);
            }
        }
    }
}
