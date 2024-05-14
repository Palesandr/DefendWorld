using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSheild : MonoBehaviour
{

    public static float shieldHealth;
    public ParticleSystem particleSystemShield;

    void Update()
    {
        transform.Rotate(0, 0, -0.8f);
    }

    public void TakeDamage(int value)
    {
        shieldHealth -= value;
        //Debug.Log(shieldHealth);
        if (shieldHealth <= 0)
        {
            particleSystemShield.Play();
            Destroy(gameObject);
        }
    }

}
