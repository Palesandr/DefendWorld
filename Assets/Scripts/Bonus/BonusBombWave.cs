using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBombWave : MonoBehaviour
{
    public int countBombWave = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController pc = collision.GetComponent<PlayerController>();

        if (pc != null)
        {
            //if (Fire.countBomb == 0)
            //{
            Fire.countBombWave += 2;
            AudioManager.instance.Play("BulletBonus");
            Destroy(gameObject);
            //}
        }
    }
}
