using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject skinsCanvas;
    public GameObject mainMenuCanvas;
    public GameObject mainMenu;
    public GameObject gameMenu;
    int isDead;
    int score;
    int isWinLevel;
    //int sumScore;
    float healthShield;
    float healtPlayer;
    int speed;
    public int priceUpgrade;


    private void Start()
    {
        isDead = PlayerPrefs.GetInt("isDead");
        //sumScore = PlayerPrefs.GetInt("money");
        isWinLevel = PlayerPrefs.GetInt("isWinLevel");
        healthShield = PlayerPrefs.GetFloat("healthShield");
        speed = PlayerPrefs.GetInt("speedPlayer");

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

    //новая игра, сбрасываем все сохранки
    public void StartGame()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("isStartGame", 1);
        PlayerPrefs.SetInt("isDead", 0);
        PlayerPrefs.SetInt("LevelID", 1);
        PlayerPrefs.SetInt("isWinLevel", 0);
        PlayerPrefs.SetInt("skinID", 0);
        PlayerPrefs.SetInt("Life", 0);
        PlayerPrefs.SetInt("money", 0);
        PlayerPrefs.SetInt("isStartGame", 1);
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
        PlayerPrefs.SetInt("finallyScore", 0);
        PlayerPrefs.SetInt("finallyCountEnemy", 0);
        PlayerPrefs.Save();
        SpawnBoss.IsBoss = false;
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    //продолжаем игру с главного меню
    public void ContinueGame()
    {
        //если не умер, грузим след. уровень
        if ((isDead == 0) && (isWinLevel == 1))
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("LevelID") + 1);
            PlayerPrefs.SetInt("isDead", 0);
            PlayerPrefs.SetInt("isWinLevel", 0);
            PlayerPrefs.SetInt("countBomb", 5);
            PlayerPrefs.Save();
            Fire.countBomb = 5;
        }

        //если умер, но очки больше 0. грузим тот же уровень, где и умер
        if (isDead == 1)
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("LevelID"));
            PlayerPrefs.SetInt("isDead", 0);
            PlayerPrefs.SetInt("isWinLevel", 0);
            PlayerPrefs.SetInt("countBomb", 5);
            PlayerPrefs.Save();
            Fire.countBomb = 5;
        }

        Debug.Log("LevelID: " + PlayerPrefs.GetInt("LevelID"));

        Time.timeScale = 1;
    }

    //улучшение шита
    public void LevelUpShield()
    {
        //вычитаем из общего числа очков
        /*score = PlayerPrefs.GetInt("money");
        score -= priceUpgrade;
        
        //получаем текущий уровень щита
        healthShield = PlayerPrefs.GetFloat("healthShield");

        //прибавляем к текущему уровню щита новое значение
        healthShield += 1;

        //сохраняем урвень щита
        PlayerPrefs.SetFloat("healthShield", healthShield);
        PlayerPrefs.SetInt("money", score);
        PlayerPrefs.Save();*/
    }

    //улучшение скорости
    public void LevelUpSpeed()
    {
        /*if (PlayerPrefs.HasKey("money"))
        {
            score -= priceUpgrade;
            buttonUpdate.interactable = true;
            speed = PlayerPrefs.GetInt("speedPlayer");
            speed += 1;

            PlayerPrefs.SetInt("speedPlayer", speed);
            PlayerPrefs.SetInt("money", score);
            PlayerPrefs.Save();
        }
        else 
        {
            buttonUpdate.interactable = false;
        }*/


    }

    //улучшение жизни
    public void LevelUpHealth()
    {
       /* if (PlayerPrefs.HasKey("money"))
        {
            score -= priceUpgrade;
            buttonUpdate.interactable = true;
            healtPlayer = PlayerPrefs.GetFloat("healthPlayer");
            healtPlayer += 1;

            PlayerPrefs.SetFloat("healthPlayer", healtPlayer);
            PlayerPrefs.SetInt("money", score);
            PlayerPrefs.Save();
        }
        else
        {
            buttonUpdate.interactable = false;
        }*/
    }


    //сброс игры
    public void ResetGame()
    {
        
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("isStartGame", 1); //новая ли игра
        PlayerPrefs.SetInt("isDead", 0); //умер или нет
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
        PlayerPrefs.SetInt("finallyScore", 0);
        PlayerPrefs.SetInt("finallyCountEnemy", 0);
        PlayerPrefs.Save();
    }



    //старт игры????????????
    public void PlayPressed()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //выход в гавное меню
    public void ExitPressed()
    {
        AudioManager.instance.Stop("ScoreSound");
        

        //sumScore += GameManagers.score;
        PlayerPrefs.SetInt("money", GameManagers.scoreTemp + GameManagers.score);
        PlayerPrefs.SetInt("isDead", 0);
        PlayerPrefs.SetInt("isWinLevel", 1);
        PlayerPrefs.SetInt("countBomb", 5);
        PlayerPrefs.SetInt("finallyScore", GameManagers.instance._tempFinallyScore);
        PlayerPrefs.SetInt("finallyCountEnemy", GameManagers.instance._tempFinallyCountEnemy);
        PlayerPrefs.Save();
        ScoreManager.maxShield = Shield.shieldHealth = PlayerPrefs.GetFloat("maxHealthShield");
        Fire.countBomb = 5;

        SceneManager.LoadScene("MainMenu");
        //ScoreManager.maxShield = PlayerPrefs.GetFloat("maxHealthShield");
    }



    //продолжить игру после победы
    public void ContinuePressed()
    {
        mainMenu.SetActive(false);
        gameMenu.SetActive(true);
        PlayerPrefs.SetInt("isWinLevel", 0);
        PlayerPrefs.SetInt("countBomb", 5);
        PlayerPrefs.SetInt("finallyScore", GameManagers.instance._finallyScore);
        PlayerPrefs.Save();
        Fire.countBomb = 5;
        Shield.shieldHealth = PlayerPrefs.GetFloat("maxHealthShield");
        Time.timeScale = 1;
    }

    //выход после смерти
    public void ExitAfterDie()
    {
        AudioManager.instance.Stop("DieSound");
        //sumScore += GameManagers.score;
        PlayerPrefs.SetInt("money", GameManagers.score);
        PlayerPrefs.SetInt("isDead", 1);
        PlayerPrefs.SetInt("isWinLevel", 0);
        PlayerPrefs.SetInt("countBomb", 5);
        PlayerPrefs.SetInt("finallyScore", GameManagers.instance._tempFinallyScore);
        PlayerPrefs.Save();
        Fire.countBomb = 5;
        Shield.shieldHealth = PlayerPrefs.GetFloat("maxHealthShield");

        //Debug.Log("sumScore: " + sumScore);
        //Debug.Log("dcore: " + GameManagers.score);

        //ScoreManager.sumScore = PlayerPrefs.GetInt("money");
        //GameManagers.score = 0;
        SceneManager.LoadScene("MainMenu");
    }

    //метод продолжения игры после смерти
    public void CotinueAfterDie()
    {
        AudioManager.instance.Stop("ScoreSound");
        mainMenu.SetActive(false);
        gameMenu.SetActive(true);

        //sumScore += GameManagers.score;
        PlayerPrefs.SetInt("money", GameManagers.score);
        Fire.countBomb = 5;
        PlayerPrefs.SetInt("countBomb", 5);
        PlayerPrefs.SetInt("isDead", 0);
        PlayerPrefs.SetInt("isWinLevel", 0);
        PlayerPrefs.SetInt("finallyScore", GameManagers.instance._tempFinallyScore);
        PlayerPrefs.Save();
        Fire.countBomb = 5;
        Shield.shieldHealth = PlayerPrefs.GetFloat("maxHealthShield");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //ScoreManager.sumScore = PlayerPrefs.GetInt("money");
        //GameManagers.score = 0;
        Time.timeScale = 1;
    }

    public void NextLevel()
    {
        AudioManager.instance.Stop("ScoreSound");
        PlayerPrefs.SetInt("isWinLevel", 0);
        PlayerPrefs.SetInt("countBomb", 5);
        PlayerPrefs.Save();
        Fire.countBomb = 5;
        Shield.shieldHealth = PlayerPrefs.GetFloat("maxHealthShield");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }
}
