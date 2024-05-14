using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusEnergy : MonoBehaviour
{
    public int countEnergy = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController pc = collision.GetComponent<PlayerController>();

        if (pc != null)
        {
            //if (Fire.countBomb == 0)
            //{
            Fire.countEnergy += 5;
            AudioManager.instance.Play("BulletBonus");
            Destroy(gameObject);
            //}
        }
    }
}
