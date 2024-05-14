using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using YG;

public class Shield : MonoBehaviour
{
    //текущее состояние щита
    public static float shieldHealth;

    //максимальный уровень щита
    public static float maxHP;

    //уровень щита
    //public int _levelShield;

    public Sprite[] spriteShield = new Sprite[4];
    public SpriteRenderer spriteRenderer;
    public static Shield instance;



    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        shieldHealth = PlayerPrefs.GetFloat("maxHealthShield");
        maxHP = PlayerPrefs.GetFloat("maxHealthShield"); 
        
        /*shieldHealth = YandexGame.savesData.maxHealthShield;
        maxHP = YandexGame.savesData.maxHealthShield;
        YandexGame.LoadProgress();*/

        spriteRenderer = GetComponent<SpriteRenderer>();


        UpgradeShield();

    }
    private void Update()
    {
        transform.Rotate(0, 0, 1f);
        UpgradeShield();
    }

    public void TakeDamage(int value)
    {
        shieldHealth -= value;
        //Debug.Log(shieldHealth);

        UpgradeShield();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BonusShield bonusShield = collision.GetComponent<BonusShield>();

        if (gameObject != null)
        {
            if (bonusShield != null)
            {
                if (shieldHealth < maxHP)
                {
                    shieldHealth += bonusShield.upShield;
                    UpgradeShield();
                    PlayerPrefs.SetFloat("healthShield", shieldHealth);
                    PlayerPrefs.Save();

                    //YandexGame.savesData.healthShield = shieldHealth;
                    //YandexGame.SaveProgress();
                }
            }
        }
    }

    public void UpgradeShield()
    {
        //Debug.Log("shieldHealth: " + shieldHealth);
        //Debug.Log(maxHP);

        if (shieldHealth <= 0)
        {
            AudioManager.instance.Play("ShieldOff");
            //Destroy(GameObject.Find("Shield"));
            spriteRenderer.enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
        }

        /*if ((shieldHealth >= 0) && (shieldHealth <= 10))
        {
            spriteRenderer.sprite = spriteShield[0];
            spriteRenderer.enabled = true;
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
        }

        if ((shieldHealth > 10) && (shieldHealth <= 20))
        {
            spriteRenderer.sprite = spriteShield[1];
            spriteRenderer.enabled = true;
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
        }

        if ((shieldHealth > 30) && (shieldHealth <= 40))
        {
            spriteRenderer.sprite = spriteShield[2];
            spriteRenderer.enabled = true;
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
        }

        if (shieldHealth > 40)
        {
            spriteRenderer.sprite = spriteShield[3];
            spriteRenderer.enabled = true;
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
        }
        
        */
        
        if (shieldHealth > 0) 
        {
            spriteRenderer.sprite = spriteShield[0];
            spriteRenderer.enabled = true;
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
        }

        if (shieldHealth > 20)
        {
            spriteRenderer.sprite = spriteShield[1];
            spriteRenderer.enabled = true;
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
        }

        if (shieldHealth > 30)
        {
            spriteRenderer.sprite = spriteShield[2];
            spriteRenderer.enabled = true;
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
        }

        if (shieldHealth > 40)
        {
            spriteRenderer.sprite = spriteShield[3];
            spriteRenderer.enabled = true;
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
        }
    }
}
