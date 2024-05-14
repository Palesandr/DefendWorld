using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
//using YG;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public int speed;
    public float offset;
    Vector2 movement;
    //Vector2 mousePos;

    public static float health;
    public static float maxHP;
    public GameObject deathEffect; //эффект смерти
    public GameObject dieMenu;
    public GameObject gameMenu;
    private SpriteRenderer spriteRenderer;
    public static PlayerController instance;
    private AudioSource[] audioSources;
    //BonusBulletManager bbm;

    //[Header("захват цели")]
    //public static GameObject enemySpotted;
    //PlayerInput _Input;
    Vector2 _Movement;
    Vector2 _MousePos;

    public ParticleSystem particleSystemDie;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //_Input = new PlayerInput();

        audioSources = FindObjectsOfType<AudioSource>();
    }


    /*private void OnMove(InputValue inputValue)
    {
        _Movement = inputValue.Get<Vector2>();

        //Vector2 _Movement = context.ReadValue<Vector2>();
    }*/


    void Start()
    {
        health = PlayerPrefs.GetFloat("maxHealthPlayer");
        maxHP = PlayerPrefs.GetFloat("maxHealthPlayer");
        speed = PlayerPrefs.GetInt("speedPlayer");

        //dieMenu = GameObject.Find("DieMenu");
        //gameMenu = GameObject.Find("Game");

        /*health = YandexGame.savesData.maxHealthPlayer;
        maxHP = YandexGame.savesData.maxHealthPlayer;
        speed = YandexGame.savesData.speedPlayer;
        YandexGame.LoadProgress();*/
    }

    private void Update()
    {
         movement.x = Input.GetAxisRaw("Horizontal");
         movement.y = Input.GetAxisRaw("Vertical");

        _MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //_MousePos = Mouse.current.position.ReadValue();
    }

    void FixedUpdate()
    {
        /*Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(_MousePos);

        // Вычисляем угол между позицией игрока и позицией курсора мыши
        float angle = Mathf.Atan2(worldMousePosition.y - transform.position.y, worldMousePosition.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        

        // Создаем вращение на полученный угол
        Quaternion rotation = Quaternion.Euler(0, 0, angle);

        // Применяем вращение к игроку
        transform.rotation = rotation;

        rb.velocity = _Movement * speed;*/

        Vector2 lookDir = _MousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        /*if (health < 3)
        {
            Debug.Log("делаем эффект бара жизни");
        }
        else 
        {
            Debug.Log("выключаем эффект бара жизни");
        }*/

        if (health <= 0)
        {
            particleSystemDie.Play();
            AudioManager.instance.Play("PlayerDie");
            Die();
        }
    }

    private void Die()
    {
        //StopAllSounds();


        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = null;

        //создаём эффект смерти
        //GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        //уничтожаем эффект
        //Destroy(effect, 0.5f);
        

        if (CoroutineTimer.instance.isTime == false)
        {
            if (SpawnBoss.instance.boss.name == "Boss1")
            {
                AudioManager.instance.Stop("MusicBoss4");
            }

            if (SpawnBoss.instance.boss.name == "Boss2")
            {
                AudioManager.instance.Stop("MusicBoss2");
            }

            if (SpawnBoss.instance.boss.name == "Boss3")
            {
                AudioManager.instance.Stop("MusicBoss5");
            }
        }
           

        //пауза в 1 секунду
        StartCoroutine(TimeDeath());
    }


    //корутина паузы для 1 секунды
    IEnumerator TimeDeath()
    {
        yield return new WaitForSeconds(0.5f);

        GameManagers.instance._roundFinallyScore = 0;
        GameManagers.instance._roundFinallyCountEnemy = 0;

        PlayerPrefs.SetInt("isDead", 1);
        PlayerPrefs.SetInt("LevelID", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("isWinLevel", 0);
        //PlayerPrefs.SetInt("finallyScore", GameManagers.instance._tempFinallyScore);
        PlayerPrefs.SetInt("countBomb", Fire.countBomb);
        PlayerPrefs.SetInt("energy", Fire.countEnergy);
        PlayerPrefs.SetInt("bombWave", Fire.countBombWave);
        PlayerPrefs.Save();

        /*YandexGame.savesData.isDead = 1;
        YandexGame.savesData.LevelID = SceneManager.GetActiveScene().buildIndex;
        YandexGame.savesData.isWinLevel = 0;
        YandexGame.savesData.finallyScore = GameManagers.instance._tempFinallyScore;
        YandexGame.savesData.countBomb = Fire.countBomb;
        YandexGame.SaveProgress();*/


        //ScoreManager.sumScore = ScoreManager.sumScore + GameManagers.score;


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

    public void StopAllSounds()
    {
        foreach (AudioSource audioSource in audioSources)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }

}
