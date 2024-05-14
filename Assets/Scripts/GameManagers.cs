using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;
using YG;
using TMPro;
//using YG;

public class GameManagers : MonoBehaviour
{
    [Header("очки")]
    public TextMeshProUGUI scoreGT;

    public static int score;
    public static int scoreTemp; //сюда записываем очки при старте уровня

    [Header("кол-во очков")]
    public int _finallyScore; //финальные очки
    public int _roundFinallyScore;

    [Header("кол-во убитых врагов")]
    public static int countEnemy;
    public int _finallyCountEnemy; //финальное кол-во убитых врагов
    public int _roundFinallyCountEnemy;
    /*[Header("количество жиней")]
    public int livePlayer;
    public Text liveGT;*/

    //public TextMeshProUGUI textKills;



    [Header("уровень щита")]
    public static int upShiled;
    //public GameObject shield;
   
    public int countEnemySpawn;
    
    [Header("кол-во врагов на раунд")]
    public int countEnemyLevel = 20;



    //public static bool game_paused = false;
    public GameObject scorePanel;
    public GameObject gameMenu;
    public static GameManagers instance;

    [Header("Убит босс")]
    public bool isBossDeath = false;

    private static bool _isCombo;
    float comboTimeLimit = 1f; // Время, в течение которого нужно убивать врагов для комбо
    //public int comboCounter = 0; // Переменная для отслеживания комбо-счетчика
    //public int scorePerKill = 10; // Количество очков за каждую смерть
    private float comboTimer = 0f; // Таймер для отслеживания времени комбо

    //Text scoreGT;
    //Enemy enemy;

    static bool _isCoins; //true если нужен подсчет очков, false если не нужно считать очки

    public static bool isCoins
    {
        get { return _isCoins; }
        set { _isCoins = value; }
    }
    public static bool isCombo
    {
        get { return _isCombo; }
        set { _isCombo = value; }
    }

    private void Awake()
    {

        _finallyScore = PlayerPrefs.GetInt("finallyScore");
        _finallyCountEnemy = PlayerPrefs.GetInt("finallyCountEnemy");

        Debug.Log("AWAKE:");
        Debug.Log("Всего очков:" + _finallyScore);
        Debug.Log("Всего убито: " + _finallyCountEnemy);
    }

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        countEnemy = 0;
        _roundFinallyScore = 0;
        _roundFinallyCountEnemy = 0;

        Shield.shieldHealth = PlayerPrefs.GetFloat("healthShield"); //уровень щита
        Shield.maxHP = PlayerPrefs.GetFloat("maxHealthShield");
        PlayerController.health = PlayerPrefs.GetFloat("healthPlayer");
        PlayerController.maxHP = PlayerPrefs.GetFloat("maxHealthPlayer");
        score = PlayerPrefs.GetInt("money");




        /*Shield.shieldHealth = YandexGame.savesData.healthShield; //уровень щита
        Shield.maxHP = YandexGame.savesData.maxHealthShield;
        PlayerController.health = YandexGame.savesData.healthPlayer;
        PlayerController.maxHP = YandexGame.savesData.maxHealthPlayer;
        _finallyScore = _tempFinallyScore = YandexGame.savesData.finallyScore;
        _finallyCountEnemy = _tempFinallyCountEnemy = YandexGame.savesData.finallyCountEnemy;
        score = YandexGame.savesData.money;
        YandexGame.LoadProgress();*/

        scoreTemp = 0;
        //scoreGT.text = score.ToString();
        scoreGT.text = "0";

        isCoins = true;

    }

    public void ComboDie()
    {

    }
    private void Update()
    {
        if (isCombo)
        {
            // Обновляем таймер комбо
            comboTimer += Time.deltaTime;

            // Если таймер превысил лимит комбо времени, обнуляем счетчик комбо
            if (comboTimer > comboTimeLimit)
            {
                //comboCounter = 0;
                comboTimer = 0f;
                isCombo = false;
                //Debug.Log("Комбо отключено!");
            }
        }


    }
    public void ChangeScore(int coinValue)
    {
        scoreTemp += coinValue;
        _roundFinallyScore += coinValue;
        scoreGT.text = scoreTemp.ToString();

        //Debug.Log("money: " + PlayerPrefs.GetInt("money"));

        //PlayerPrefs.SetInt("money", score + scoreTemp);
        //PlayerPrefs.SetInt("finallyScore", _finallyScore);
        //PlayerPrefs.Save();
        //Debug.Log("Всего очков: " + _finallyScore);

        //textKills.text = countEnemy.ToString() + " из " + SpawnBoss.afterSpawnBoss.ToString();
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
        _roundFinallyCountEnemy++;

        //если убитых врагов равно 30, то включаем спаун босса, но не сам спаун босса
        if (countEnemy == 30)
        {
            SpawnBoss.IsBoss = true;
        }


        //PlayerPrefs.SetInt("finallyCountEnemy", _finallyCountEnemy);
        //PlayerPrefs.Save();

        //YandexGame.savesData.finallyCountEnemy = _finallyCountEnemy;
        //YandexGame.SaveProgress();

        //Debug.Log("Всего убито: " + _finallyCountEnemy);
        //Debug.Log("убито: " + countEnemy);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("LevelID", SceneManager.GetActiveScene().buildIndex); //текущий уровень
        PlayerPrefs.SetFloat("healthShield", Shield.maxHP); //уровень щита
        PlayerPrefs.SetFloat("maxHealthShield", Shield.maxHP);
        PlayerPrefs.SetFloat("healthPlayer", PlayerController.maxHP); //уровень жизни
        PlayerPrefs.SetFloat("maxHealthPlayer", PlayerController.maxHP);
        //PlayerPrefs.SetInt("money", scoreTemp);
        //PlayerPrefs.SetInt("finallyScore", _finallyScore);
        PlayerPrefs.SetInt("isDead", 1);
        PlayerPrefs.Save();

        /*YandexGame.savesData.healthShield = Shield.maxHP; //уровень щита
        YandexGame.savesData.maxHealthShield = Shield.maxHP;
        YandexGame.savesData.healthPlayer = PlayerController.health; //уровень жизни
        YandexGame.savesData.maxHealthPlayer = PlayerController.maxHP;
        YandexGame.savesData.money = scoreTemp;
        YandexGame.savesData.finallyScore = _tempFinallyScore;
        YandexGame.savesData.isDead = 1;

        
        YandexGame.SaveProgress();*/
    }

    public void ShowMenuAfterDieBoss(bool _isDie)
    {


        int finallyS = _finallyScore + _roundFinallyScore;
        int finallyE = _finallyCountEnemy + _roundFinallyCountEnemy;

        CoroutineTimer.instance.textScore.text = scoreTemp.ToString();
        CoroutineTimer.instance.textKill.text = countEnemy.ToString();

        if (CoroutineTimer.instance.isFinallyLevel == true)
        {
            CoroutineTimer.instance.textAllScore.text = finallyS.ToString();
            CoroutineTimer.instance.textAllKill.text = finallyE.ToString();
        }

        PlayerPrefs.SetInt("finallyScore", finallyS);
        PlayerPrefs.SetInt("finallyCountEnemy", finallyE);
        PlayerPrefs.SetInt("nextLevelID", SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.SetInt("isWinLevel", 1);
        PlayerPrefs.SetInt("isDead", 0);
        PlayerPrefs.SetInt("money", score + scoreTemp);
        PlayerPrefs.Save();

        /*YandexGame.savesData.LevelID = SceneManager.GetActiveScene().buildIndex;
        YandexGame.savesData.isWinLevel = 1;
        YandexGame.savesData.isDead = 0;
        YandexGame.savesData.money = score + scoreTemp;
        YandexGame.savesData.finallyScore = instance._finallyScore;
        YandexGame.SaveProgress();*/

        StartCoroutine(ShowMenu());


    }

    IEnumerator ShowMenu()
    {
        yield return new WaitForSeconds(2);

        AudioManager.instance.Play("ScoreSound1");

        scorePanel.SetActive(true);
        instance.gameMenu.SetActive(false);
        Time.timeScale = 0;
    }


}
