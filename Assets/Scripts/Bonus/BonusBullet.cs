using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBullet : MonoBehaviour
{
    public int upBullet = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController pc = collision.GetComponent<PlayerController>();

        if (pc != null)
        {
            AudioManager.instance.Play("BulletBonus");
            Destroy(gameObject);
        }
    }
}
