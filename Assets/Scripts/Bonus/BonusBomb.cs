using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBomb : MonoBehaviour
{
    public int countBomb = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController pc = collision.GetComponent<PlayerController>();

        if (pc != null)
        {
            //if (Fire.countBomb == 0)
            //{
                Fire.countBomb += 5;
                AudioManager.instance.Play("BulletBonus");
                Destroy(gameObject);
            //}
        }
    }
}
