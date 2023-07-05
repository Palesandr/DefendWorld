using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public int speed;
    public float offset;
    Vector2 movement;
    Vector2 mousePos;
    public static float health;
    public static float maxHP;
    public GameObject deathEffect; //эффект смерти
    public GameObject dieMenu;
    public GameObject gameMenu;
    private SpriteRenderer spriteRenderer;
    public static PlayerController instance;
    //BonusBulletManager bbm;
    
    //[Header("захват цели")]
    //public static GameObject enemySpotted;


    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        //dieMenu = GameObject.Find("DieMenu");

        health = PlayerPrefs.GetFloat("maxHealthPlayer");
        maxHP = PlayerPrefs.GetFloat("maxHealthPlayer");
        speed = PlayerPrefs.GetInt("speedPlayer");
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Debug.Log(enemySpotted);
    }

    void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        //Debug.Log("health: " + health);
        //Debug.Log("damage: " + damage);

        if (health < 3)
        {
            Debug.Log("делаем эффект бара жизни");
        }
        else 
        {
            Debug.Log("выключаем эффект бара жизни");
        }

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = null;

        //создаём эффект смерти
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        //уничтожаем эффект
        Destroy(effect, 0.5f);

        if (CoroutineTimer.instance.isTime == false)
        {


            for (int i = 0; i < SpawnBoss.instance.boss.Length; i++)
            {
                if (SpawnBoss.instance.boss[i].name == "Boss1")
                {
                    AudioManager.instance.Stop("MusicBoss1");
                }

                if (SpawnBoss.instance.boss[i].name == "Boss2")
                {
                    AudioManager.instance.Stop("MusicBoss2");
                }

                if (SpawnBoss.instance.boss[i].name == "Boss3")
                {
                    AudioManager.instance.Stop("MusicBoss3");
                }
            }
        }
           

        //пауза в 1 секунду
        StartCoroutine(TimeDeath());

        



        //если жизни больше 0
        /*if (GameManagers.instance.livePlayer < 0)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.4f);

            Time.timeScale = 0;
            dieMenu.SetActive(true);
        }
        else
        {
            //если меньше 0
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.4f);

            Time.timeScale = 0;
            GameManagers.instance.MinusLive(1);
            Destroy(gameObject);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            dieMenu.SetActive(true);
        }*/



        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);



    }

    //корутина паузы для 1 секунды
    IEnumerator TimeDeath()
    {
        yield return new WaitForSeconds(0.5f);

        PlayerPrefs.SetInt("isDead", 1);
        PlayerPrefs.SetInt("LevelID", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("isWinLevel", 0);
        PlayerPrefs.SetInt("finallyScore", GameManagers.instance._tempFinallyScore);
        PlayerPrefs.SetInt("countBomb", Fire.countBomb);
        PlayerPrefs.Save();
        ScoreManager.sumScore = ScoreManager.sumScore + GameManagers.score;
        //PlayerPrefs.SetInt("money", GameManagers.score);
        

        /*GameManagers.instance.MinusLive(1);

        PlayerPrefs.SetInt("Life", GameManagers.instance.livePlayer);
        PlayerPrefs.Save();*/
        yield return new WaitForSeconds(0.4f);
        //вызываем меню

        gameMenu.SetActive(false);
        dieMenu.SetActive(true);
        AudioManager.instance.Play("DieSound");

        //замираем время
        Time.timeScale = 0;

        //уничтожаем игрока
        Destroy(gameObject);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        BonusHealth bonusHealth = collision.GetComponent<BonusHealth>();
        

        if (gameObject != null)
        {
            if (bonusHealth != null)
            {
                if (health < maxHP) 
                {
                    //Debug.Log("upHealth:   " + bonusHealth.upHealth);
                    health += bonusHealth.upHealth;
                }
            }
        }

    }
}
