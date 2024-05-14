using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCreate : MonoBehaviour
{
    public ParticleSystem particleSystemShield; 
    bool onShield;

    private void Start()
    {
        onShield = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController pc = collision.GetComponent<PlayerController>();

        if (pc != null)
        {
            //если меньше максимального значения и больше 0
            if ((Shield.shieldHealth < Shield.maxHP) && (Shield.shieldHealth > 0))
            {
                if (onShield)
                {
                    Shield.shieldHealth = Shield.maxHP;
                    //Shield.SpriteRenderer.enabled = true;
                    //PlayerController pc = collision.GetComponent<PlayerController>();
                    AudioManager.instance.Play("ShieldBonus");
                    onShield = false;
                    UpgradeShield();
                    particleSystemShield.Play();
                    StartCoroutine(startShield());
                }
                //Destroy(gameObject);
            }

            //меньше или равно 0, то включаем коллайдер щита
            if (Shield.shieldHealth <= 0)
            {
                if (onShield)
                {
                    Shield.shieldHealth = Shield.maxHP;
                    GameObject.Find("PlayerShield").GetComponent<CircleCollider2D>().enabled = true;
                    //Shield.SpriteRenderer.enabled = true;
                    //PlayerController pc = collision.GetComponent<PlayerController>();
                    AudioManager.instance.Play("ShieldBonus");
                    //Destroy(gameObject);
                    onShield = false;
                    UpgradeShield();
                    particleSystemShield.Play();
                    StartCoroutine(startShield());
                }
            }

            /*Instantiate(effectShield, transform.position, transform.rotation);
            Destroy(effectShield);*/

            
        }
    }

    IEnumerator startShield()
    {
        yield return new WaitForSeconds(10f);
        onShield = true;
    }

    void UpgradeShield()
    {
        //Debug.Log("shieldHealth: " + shieldHealth);
        //Debug.Log(maxHP);

        if (Shield.shieldHealth <= 0)
        {
            AudioManager.instance.Play("ShieldOff");
            //Destroy(GameObject.Find("Shield"));
            Shield.instance.spriteRenderer.enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }

        if ((Shield.shieldHealth >= 0) && (Shield.shieldHealth <= 10))
        {
            Shield.instance.spriteRenderer.sprite = Shield.instance.spriteShield[0];
            Shield.instance.spriteRenderer.enabled = true;
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
        }

        if ((Shield.shieldHealth > 10) && (Shield.shieldHealth <= 20))
        {
            Shield.instance.spriteRenderer.sprite = Shield.instance.spriteShield[1];
            Shield.instance.spriteRenderer.enabled = true;
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
        }

        if ((Shield.shieldHealth > 30) && (Shield.shieldHealth <= 40))
        {
            Shield.instance.spriteRenderer.sprite = Shield.instance.spriteShield[2];
            Shield.instance.spriteRenderer.enabled = true;
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
        }

        if (Shield.shieldHealth > 40)
        {
            Shield.instance.spriteRenderer.sprite = Shield.instance.spriteShield[3];
            Shield.instance.spriteRenderer.enabled = true;
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
        }
    }
}
