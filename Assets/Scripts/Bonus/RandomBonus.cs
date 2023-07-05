using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomBonus : MonoBehaviour
{
    int r; //рандомный бонус, всего 4 штуки (жизнь, щит, очки)
    GameObject Player;
    //public TextMeshProUGUI t;
    BulletAnimation ba;
    //public Animator anim;
    // GameObject floatingBonus;


    void Start()
    {
        r = Random.Range(0, 4);
        //Debug.Log(r);


        Player = GameObject.FindGameObjectWithTag("Player");
        // anim = Resources.Load<AnimationClip>("Animations/Idle");
        ba = GameObject.FindAnyObjectByType<BulletAnimation>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Player != null)
        {
            
            switch (r)
            {
                case 0:
                    plusHealth();
                    break;
                case 1:
                    plusShield();
                    break;
                case 2:
                    plusBullet();
                    break;
                case 3:
                    plusScore();
                    break;
                case 4:
                    plusBomb();
                    break;
                default:
                    break;
            }

            
        }
    }

    void plusHealth()
    {
        if (PlayerController.health < PlayerController.maxHP) 
        {
            PlayerController.health += 2;
        }
        /*FloatingBonus.instance.spriteRenderer.sprite = FloatingBonus.instance.spriteShield[2];
        FloatingBonus.instance.spriteRenderer.enabled = true;
        GameObject prefab = Instantiate(floatingBonus, transform.position, Quaternion.identity);*/
        AudioManager.instance.Play("HealthBonus");
        Destroy(gameObject);
    }

    void plusShield()
    {
        if (Shield.shieldHealth < Shield.maxHP)
        {
            Shield.shieldHealth = Shield.maxHP;
        }
        /*FloatingBonus.instance.spriteRenderer.sprite = FloatingBonus.instance.spriteShield[1];
        FloatingBonus.instance.spriteRenderer.enabled = true;
        GameObject prefab = Instantiate(floatingBonus, transform.position, Quaternion.identity);*/
        AudioManager.instance.Play("ShieldBonus");
        Destroy(gameObject);
    }

    void plusBullet()
    {
        //Debug.Log(ba.xp);

        ba.LevelUp();

        Fire.updBullet = ba.xp;

        if (ba.xp % 2 == 0)
        {
            Fire.bulletForce += 1f;
        }


        AudioManager.instance.Play("BulletBonus");
        Destroy(gameObject);
    }

    void plusScore()
    {
        GameManagers.scoreTemp += 100;
        Destroy(gameObject);
    }

    void plusBomb()
    {
        Fire.countBomb =+ 5;
        //Debug.Log("Bomp plus 5");
        /*FloatingBonus.instance.spriteRenderer.sprite = FloatingBonus.instance.spriteShield[3];
        FloatingBonus.instance.spriteRenderer.enabled = true;
        GameObject prefab = Instantiate(floatingBonus, transform.position, Quaternion.identity);*/
        AudioManager.instance.Play("BulletBonus");
        Destroy(gameObject);
    }

}
