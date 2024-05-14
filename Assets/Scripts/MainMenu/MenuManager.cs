using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using YG;

public class MenuManager : MonoBehaviour
{
    public GameObject skinsCanvas;
    public GameObject mainMenuCanvas;
    public GameObject mainMenu;
    public GameObject gameMenu;
    public GameObject howPlay;
    int isDead;
    int score;
    int isWinLevel;
    //int sumScore;
    float healthShield;
    float healtPlayer;
    int speed;
    public int priceUpgrade;
    private AudioSource[] audioSources;

    private void Awake()
    {
        audioSources = FindObjectsOfType<AudioSource>();
    }

    private void Start()
    {
               

        isDead = PlayerPrefs.GetInt("isDead");
        //sumScore = PlayerPrefs.GetInt("money");
        isWinLevel = PlayerPrefs.GetInt("isWinLevel");
        healthShield = PlayerPrefs.GetFloat("healthShield");
        speed = PlayerPrefs.GetInt("speedPlayer");
        
        /*isDead = YandexGame.savesData.isDead;
        //sumScore = PlayerPrefs.GetInt("money");
        isWinLevel = YandexGame.savesData.isWinLevel;
        healthShield = YandexGame.savesData.healthShield;
        speed = YandexGame.savesData.speedPlayer;*/

        //Debug.Log("healthShield:" + healthShield);
    }

    //открыть меню скинов
    public void OpenSkins()
    {
        skinsCanvas.SetActive(true);
        mainMenuCanvas.SetActive(false);
    }

    //закрыть меню скинов
    public void CloseSkins()
    {
        skinsCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }

    public void OpenHowToPlay()
    {
        howPlay.SetActive(true);
        mainMenuCanvas.SetActive(false);
    }
    
    public void CloseHowToPlay()
    {
        howPlay.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }

    //новая игра, сбрасываем все сохранки
    public void StartGame()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("isStartGame", 1);
        PlayerPrefs.SetInt("isSound", 1);
        PlayerPrefs.SetInt("isDead", 1);
        PlayerPrefs.SetInt("isWinLevel", 0);
        PlayerPrefs.SetInt("LevelID", 1);
        PlayerPrefs.SetInt("skinID", 0);
        PlayerPrefs.SetInt("Life", 0);
        PlayerPrefs.SetInt("money", 0);
        PlayerPrefs.SetFloat("healthShield", 10);
        PlayerPrefs.SetFloat("maxHealthShield", 10);
        PlayerPrefs.SetInt("damageBullet", 1);
        PlayerPrefs.SetFloat("speedBullet", 20);
        PlayerPrefs.SetInt("speedPlayer", 8);
        PlayerPrefs.SetFloat("maxUP", 10);
        PlayerPrefs.SetFloat("updBullet", 1);
        PlayerPrefs.SetFloat("healthPlayer", 10);
        PlayerPrefs.SetFloat("maxHealthPlayer", 10);
        PlayerPrefs.SetInt("countBomb", 5);
        PlayerPrefs.SetInt("energy", 0);
        PlayerPrefs.SetInt("bombWave", 0);
        PlayerPrefs.SetInt("finallyScore", 0);
        PlayerPrefs.SetInt("finallyCountEnemy", 0);
        PlayerPrefs.SetInt("isReklama", 0); //0 - не показываем рекламу, 1 - показываем рекламу
        PlayerPrefs.Save();

        /*YandexGame.ResetSaveProgress();
        YandexGame.savesData.isStartGame = 1;
        YandexGame.savesData.isDead = 0;
        YandexGame.savesData.LevelID = 1;
        YandexGame.savesData.isWinLevel = 0;
        YandexGame.savesData.skinID = 0;
        YandexGame.savesData.money = 0;
        YandexGame.savesData.healthShield = 10;
        YandexGame.savesData.maxHealthShield = 10;
        YandexGame.savesData.damageBullet = 1;
        YandexGame.savesData.speedBullet = 20;
        YandexGame.savesData.speedPlayer = 8;
        YandexGame.savesData.maxUP = 10;
        YandexGame.savesData.updBullet = 1;
        YandexGame.savesData.healthPlayer = 10;
        YandexGame.savesData.maxHealthPlayer = 10;
        YandexGame.savesData.countBomb = 5;
        YandexGame.savesData.finallyScore = 0;
        YandexGame.savesData.finallyCountEnemy = 0;
        YandexGame.SaveProgress();*/
        SpawnBoss.IsBoss = false;
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    //продолжаем игру с главного меню
    public void ContinueGame()
    {
        int nextlevelid = PlayerPrefs.GetInt("nextLevelID");
        int levelid = PlayerPrefs.GetInt("LevelID");

        if ((nextlevelid == 0) && (levelid == 1) && (isDead == 1) && (isWinLevel == 0))
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("LevelID"));
            PlayerPrefs.SetInt("isDead", 1);
            PlayerPrefs.SetInt("isWinLevel", 0);
            PlayerPrefs.SetInt("countBomb", 5);
            PlayerPrefs.SetInt("energy", 0);
            PlayerPrefs.SetInt("bombWave", 0);
           // PlayerPrefs.SetInt("money", GameManagers.score);
            PlayerPrefs.Save();
            //Debug.Log("111111111111111111");
        }

        //Debug.Log("Level: " + PlayerPrefs.GetInt("LevelID"));
        //если не умер, грузим след. уровень
        if ((isDead == 0) && (isWinLevel == 1))
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("nextLevelID"));
            PlayerPrefs.SetInt("isDead", 1);
            PlayerPrefs.SetInt("isWinLevel", 0);
            PlayerPrefs.SetInt("countBomb", 5);
            PlayerPrefs.SetInt("energy", 0);
            PlayerPrefs.SetInt("bombWave", 0);
           // PlayerPrefs.SetInt("money", GameManagers.score);
            PlayerPrefs.Save();
            //Debug.Log("2222222222222222222");
            /*SceneManager.LoadScene(YandexGame.savesData.LevelID + 1);
            YandexGame.savesData.isDead = 0;
            YandexGame.savesData.isWinLevel = 0;
            YandexGame.savesData.countBomb = 5;
            YandexGame.SaveProgress();*/

            Fire.countBomb = 5;
            Fire.countEnergy = 0;
            Fire.countBombWave = 0;
        }
        
        if ((nextlevelid > 1) && (isDead == 1) && (isWinLevel == 0))
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("nextLevelID"));
            PlayerPrefs.SetInt("isDead", 1);
            PlayerPrefs.SetInt("isWinLevel", 0);
            PlayerPrefs.SetInt("countBomb", 5);
            PlayerPrefs.SetInt("energy", 0);
            PlayerPrefs.SetInt("bombWave", 0);
           // PlayerPrefs.SetInt("money", GameManagers.score);
            PlayerPrefs.Save();
            //Debug.Log("33333333333333333333333333");
            /*SceneManager.LoadScene(YandexGame.savesData.LevelID + 1);
            YandexGame.savesData.isDead = 0;
            YandexGame.savesData.isWinLevel = 0;
            YandexGame.savesData.countBomb = 5;
            YandexGame.SaveProgress();*/

            Fire.countBomb = 5;
            Fire.countEnergy = 0;
            Fire.countBombWave = 0;
        }

        //если умер, но очки больше 0. грузим тот же уровень, где и умер
        /*if (isDead == 1)
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("LevelID"));
            PlayerPrefs.SetInt("isDead", 1);
            PlayerPrefs.SetInt("isWinLevel", 0);
            PlayerPrefs.SetInt("countBomb", 5);
            PlayerPrefs.SetInt("energy", 0);
            PlayerPrefs.SetInt("bombWave", 0);
            PlayerPrefs.Save();
            Debug.Log("44444444444444444444444444");


            Fire.countBomb = 5;
            Fire.countEnergy = 0;
            Fire.countBombWave = 0;
        }*/

       /* Debug.Log("isDead: " + isDead);
        Debug.Log("isWinLevel: " + isWinLevel);
        Debug.Log("LevelID: " + PlayerPrefs.GetInt("LevelID"));
        Debug.Log("nextLevelID: " + PlayerPrefs.GetInt("nextLevelID"));
        Debug.Log("money: " + PlayerPrefs.GetInt("money"));
        Debug.Log("isSound: " + PlayerPrefs.GetInt("isSound"));*/

        Time.timeScale = 1;
    }


    //сброс игры
    public void ResetGame()
    {
        
        PlayerPrefs.DeleteAll();
       /* PlayerPrefs.SetInt("isStartGame", 1); //новая ли игра
        PlayerPrefs.SetInt("isDead", 0); //умер или нет
        PlayerPrefs.SetInt("isSound", 1);
        PlayerPrefs.SetInt("LevelID", 1); //номер уровня
        PlayerPrefs.SetInt("isWinLevel", 0); //победа или нет
        PlayerPrefs.SetInt("skinID", 0); //номер скина
        PlayerPrefs.SetInt("Life", 0); //жизни
        PlayerPrefs.SetInt("money", 500); //очки
        PlayerPrefs.SetInt("isStartGame", 1); //старт игры или нет
        PlayerPrefs.SetFloat("healthShield", 10); //уровень щита
        PlayerPrefs.SetFloat("maxHealthShield", 10); //максимальный уровень щита
        //PlayerPrefs.SetInt("damageBullet", 1); //урон от пули
        PlayerPrefs.SetFloat("speedBullet", 20); //скорость пули
        PlayerPrefs.SetInt("speedPlayer", 8); //скорость игрока
        PlayerPrefs.SetFloat("maxUP", 10);
        PlayerPrefs.SetFloat("updBullet", 1);
        PlayerPrefs.SetFloat("healthPlayer", 10); //жизнь игрока
        PlayerPrefs.SetFloat("maxHealthPlayer", 10); //максимальная жизнь игрока
        PlayerPrefs.SetInt("countBomb", 5); //колчество бомб в начале игры
        PlayerPrefs.SetInt("energy", 0);
        PlayerPrefs.SetInt("bombWave", 0);
        PlayerPrefs.SetInt("finallyScore", 0);
        PlayerPrefs.SetInt("finallyCountEnemy", 0);
        PlayerPrefs.Save();*/
    }



    //старт игры????????????
    public void PlayPressed()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

   
    //продолжить игру после паузы
    public void ContinuePressed()
    {
        AudioManager.instance.Stop("ScoreSound1");


        mainMenu.SetActive(false);
        if (CoroutineTimer.instance._isPlay == 0)
        {
            gameMenu.SetActive(true);
        }
        

        //YandexGame.LoadProgress();
        Time.timeScale = 1;
    }



    //выход после смерти
    public void ExitAfterDie()
    {
        AudioManager.instance.Stop("DieSound");
        //sumScore += GameManagers.score;
        PlayerPrefs.SetInt("money", GameManagers.score);
        PlayerPrefs.SetInt("isDead", 1);
        PlayerPrefs.SetInt("isReklama", 0);
        PlayerPrefs.SetInt("isWinLevel", 0);
        PlayerPrefs.SetInt("countBomb", 5);
        PlayerPrefs.SetInt("energy", 0);
        PlayerPrefs.SetInt("bombWave", 0);
        PlayerPrefs.SetInt("finallyScore", GameManagers.instance._finallyScore);
        PlayerPrefs.Save();

        Fire.countBomb = 5;
        Shield.shieldHealth = PlayerPrefs.GetFloat("maxHealthShield");
        //Shield.shieldHealth = YandexGame.savesData.maxHealthShield;
        //YandexGame.LoadProgress();

        //Debug.Log("sumScore: " + sumScore);
        //Debug.Log("dcore: " + GameManagers.score);

        //ScoreManager.sumScore = PlayerPrefs.GetInt("money");
        //GameManagers.score = 0;
        SceneManager.LoadScene("MainMenu");
    }

    //метод продолжения игры после смерти
    public void CotinueAfterDie()
    {
        AudioManager.instance.Stop("DieSound");
        mainMenu.SetActive(false);
        gameMenu.SetActive(true);

        //sumScore += GameManagers.score;
        Fire.countBomb = 5;
        Fire.countEnergy = 0;
        Fire.countBombWave = 0;
        GameManagers.instance._roundFinallyScore = 0;
        GameManagers.instance._roundFinallyCountEnemy = 0;

        PlayerPrefs.SetInt("money", GameManagers.score);
        PlayerPrefs.SetInt("countBomb", 5);
        //PlayerPrefs.SetInt("energy", 0);
        //PlayerPrefs.SetInt("bombWave", 0);
        PlayerPrefs.SetInt("isDead", 1);
        PlayerPrefs.SetInt("isWinLevel", 0);
        PlayerPrefs.SetInt("finallyScore", GameManagers.instance._finallyScore);
        PlayerPrefs.Save(); 

        Shield.shieldHealth = PlayerPrefs.GetFloat("maxHealthShield");
        //Shield.shieldHealth = YandexGame.savesData.maxHealthShield;
        //YandexGame.LoadProgress();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //ScoreManager.sumScore = PlayerPrefs.GetInt("money");
        //GameManagers.score = 0;
        Time.timeScale = 1;
    }

    //выход в гавное меню
    public void ExitPressed()
    {
        //AudioManager.instance.Stop("ScoreSound");
        StopAllSounds();

        //sumScore += GameManagers.score;
        PlayerPrefs.SetInt("money", GameManagers.scoreTemp + GameManagers.score);
        PlayerPrefs.SetInt("isDead", 0);
        PlayerPrefs.SetInt("isWinLevel", 1);
        PlayerPrefs.SetInt("isReklama", 1);
        PlayerPrefs.SetInt("countBomb", 5);
        PlayerPrefs.SetInt("energy", 0);
        PlayerPrefs.SetInt("bombWave", 0);
        /*PlayerPrefs.SetInt("finallyScore", GameManagers.instance._finallyScore);
        PlayerPrefs.SetInt("finallyCountEnemy", GameManagers.instance._finallyCountEnemy);*/

        PlayerPrefs.Save();

        ScoreManager.maxShield = Shield.shieldHealth = PlayerPrefs.GetFloat("maxHealthShield");
 
        Fire.countBomb = 5;
        Fire.countEnergy = 0;
        Fire.countBombWave = 0;
        SceneManager.LoadScene("MainMenu");
        //ScoreManager.maxShield = PlayerPrefs.GetFloat("maxHealthShield");
    }

    //продолжить игру после победы
    public void NextLevel()
    {
        AudioManager.instance.Stop("ScoreSound1");

        PlayerPrefs.SetInt("isDead", 1);
        PlayerPrefs.SetInt("isWinLevel", 0);
        PlayerPrefs.SetInt("countBomb", 5);
        PlayerPrefs.SetInt("energy", 0);
        PlayerPrefs.SetInt("bombWave", 0);
        PlayerPrefs.Save();

        Fire.countBomb = 5;
        Fire.countEnergy = 0;
        Fire.countBombWave = 0;

        Shield.shieldHealth = PlayerPrefs.GetFloat("maxHealthShield");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }

    void StopAllSounds()
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
