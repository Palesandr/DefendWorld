using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;

public class GameManagers : MonoBehaviour
{
    [Header("очки")]
    public Text scoreGT;
    public static int score;
    public static int scoreTemp; //сюда записываем очки при старте уровня

    public int _finallyScore; //финальные очки
    public int _tempFinallyScore; 

    [Header("количество жиней")]
    public int livePlayer;
    public Text liveGT;



    [Header("уровень щита")]
    public static int upShiled;
    public GameObject shield;
   
    public int countEnemySpawn;
    
    [Header("кол-во врагов на раунд")]
    public int countEnemyLevel = 20;

    [Header("кол-во убитых врагов")]
    public static int countEnemy;
    public int _finallyCountEnemy; //финальное кол-во убитых врагов
    public int _tempFinallyCountEnemy;

    //public static bool game_paused = false;
    public GameObject scorePanel;
    public GameObject gameMenu;
    public static GameManagers instance;

    [Header("Убит босс")]
    public bool isBossDeath = false;

    //Text scoreGT;
    //Enemy enemy;



    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        countEnemy = 0;

        Shield.shieldHealth = PlayerPrefs.GetFloat("healthShield"); //уровень щита
        Shield.maxHP = PlayerPrefs.GetFloat("maxHealthShield");
        PlayerController.health = PlayerPrefs.GetFloat("healthPlayer");
        PlayerController.maxHP = PlayerPrefs.GetFloat("maxHealthPlayer");
        _finallyScore = _tempFinallyScore = PlayerPrefs.GetInt("finallyScore");
        _finallyCountEnemy = _tempFinallyCountEnemy = PlayerPrefs.GetInt("finallyCountEnemy");
        score = PlayerPrefs.GetInt("money");
        scoreTemp = 0;
        scoreGT.text = score.ToString();

    }

    //прибавляем жизнь
    public void PlusLive(int liveValue)
    {
        livePlayer += liveValue;
        liveGT.text = livePlayer.ToString();
        PlayerPrefs.SetInt("Life", livePlayer);
        PlayerPrefs.Save();
    }

    //отнимаем жизнь
    public void MinusLive(int liveValue)
    {
        livePlayer -= liveValue;
        liveGT.text = livePlayer.ToString();

        if (livePlayer < 1)
        {
            PlayerPrefs.SetInt("isStartGame", 0);
            scorePanel.SetActive(true);
            gameMenu.SetActive(false);
            Time.timeScale = 0;
        }

        PlayerPrefs.SetInt("Life", livePlayer);
        PlayerPrefs.Save();
    }


    public void ChangeScore(int coinValue)
    {
        scoreTemp += coinValue;
        _finallyScore += coinValue;
        scoreGT.text = "Очки: " + scoreTemp.ToString();
       //PlayerPrefs.SetInt("money", score + scoreTemp);
        //PlayerPrefs.SetInt("finallyScore", _finallyScore);
        //PlayerPrefs.Save();
        //Debug.Log("Всего очков: " + _finallyScore);
    }

    public void ChangeShield(int shieldValue)
    {
        upShiled += shieldValue;
    }

    public void PlusCount(int countValue)
    {
        countEnemySpawn++;
    }

    public void MinusCount(int countValue)
    {
        countEnemySpawn--;
    }

    public void MinusEnemy(int countValue)
    {
        countEnemyLevel--;
        //Debug.Log(countEnemyLevel);
        if (countEnemyLevel == 0)
        {
            Time.timeScale = 0;
            scorePanel.SetActive(true);
            gameMenu.SetActive(false);
        }
    }

    public void CountEnemy()
    {
        countEnemy++;
        _finallyCountEnemy++;

        //если убитых врагов равно 30, то включаем спаун босса, но не сам спаун босса
        if (countEnemy == 30)
        {
            SpawnBoss.IsBoss = true;
        }

        PlayerPrefs.SetInt("finallyCountEnemy", _finallyCountEnemy);
        PlayerPrefs.Save();

        //Debug.Log("Всего убито: " + _finallyCountEnemy);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("healthShield", Shield.maxHP); //уровень щита
        PlayerPrefs.SetFloat("maxHealthShield", Shield.maxHP);
        PlayerPrefs.SetFloat("healthPlayer", PlayerController.health); //уровень жизни
        PlayerPrefs.SetFloat("maxHealthPlayer", PlayerController.maxHP);
        PlayerPrefs.SetInt("money", scoreTemp);
        PlayerPrefs.SetInt("finallyScore", _tempFinallyScore);
        PlayerPrefs.SetInt("isDead", 1);

        PlayerPrefs.Save();
    }

    public void ShowMenuAfterDieBoss(bool _isDie)
    {
        CoroutineTimer.instance.textScore.text = score.ToString();
        CoroutineTimer.instance.textKill.text = countEnemy.ToString();
        PlayerPrefs.SetInt("LevelID", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("isWinLevel", 1);
        PlayerPrefs.SetInt("isDead", 0);
        PlayerPrefs.SetInt("money", score + scoreTemp);
        PlayerPrefs.SetInt("finallyScore", instance._finallyScore);
        PlayerPrefs.Save();

        StartCoroutine(ShowMenu());


    }

    IEnumerator ShowMenu()
    {
        yield return new WaitForSeconds(2);

        scorePanel.SetActive(true);
        instance.gameMenu.SetActive(false);
        Time.timeScale = 0;
    }
}
