using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using YG;

public class ScoreManager : MonoBehaviour
{
    [Header("очки")]
    public TextMeshProUGUI scoreGT;


    public static int sumScore;
    public static float maxShield;
    public static float health;
    public static float speed;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textShield;
    public TextMeshProUGUI textSpeed;
    public TextMeshProUGUI textHealth;
    int isDead;
    int isWinLevel;
    public Button continueButton;
    public Button buttonShield;
    public Button buttonSpeed;
    public Button buttonHealth;
    public Button buttonReklama;
    int isReklama;
    public ParticleSystem particleSystemDie;



    void Start()
    {
        int levelID = PlayerPrefs.GetInt("nextLevelID");
        //Debug.Log("LevelID: " + PlayerPrefs.GetInt("LevelID"));

        if (levelID > 1)
        {
            continueButton.gameObject.SetActive(true);
        }
        else {
            continueButton.gameObject.SetActive(false);
        }

       /* Debug.Log("isDead: " + isDead);
        Debug.Log("isWinLevel: " + isWinLevel);
        Debug.Log("LevelID: " + PlayerPrefs.GetInt("LevelID"));
        Debug.Log("nextLevelID: " + PlayerPrefs.GetInt("nextLevelID"));
        Debug.Log("finallyScore: " + PlayerPrefs.GetInt("finallyScore"));
        Debug.Log("isSound: " + PlayerPrefs.GetInt("isSound"));
        Debug.Log("money: " + PlayerPrefs.GetInt("money"));*/

         if (!PlayerPrefs.HasKey("isSound"))
         {
             PlayerPrefs.SetInt("isSound", 1);
         }

        // isReklama = PlayerPrefs.GetInt("isReklama");

        /*if (PlayerPrefs.GetInt("isReklama") == 1)
        {
            buttonReklama.gameObject.SetActive(true);
        }
        else {
            buttonReklama.gameObject.SetActive(false);
        }*/

        sumScore = PlayerPrefs.GetInt("money");
        //sumScore = YandexGame.savesData.money;
        //sumScore = sumScore + GameManagers.score;

        //показать кнопку "Продолжить" на главном меню
        isDead = PlayerPrefs.GetInt("isDead");
        isWinLevel = PlayerPrefs.GetInt("isWinLevel");

        /*isDead = YandexGame.savesData.isDead;
        isWinLevel = YandexGame.savesData.isWinLevel;

        YandexGame.LoadProgress();*/

        particleSystemDie.Play();


    }

    private void Update() 
    {
        /*PlayerPrefs.SetInt("isSound", 1);*/

        if (PlayerPrefs.GetInt("isReklama") == 1)
        {
            buttonReklama.gameObject.SetActive(true);
        }
        else
        {
            buttonReklama.gameObject.SetActive(false);
        }

        sumScore = PlayerPrefs.GetInt("money");
        //sumScore = YandexGame.savesData.money;
        textScore.text = sumScore.ToString();

        maxShield = PlayerPrefs.GetFloat("maxHealthShield"); 
        //maxShield = YandexGame.savesData.maxHealthShield;
        textShield.text = maxShield.ToString();

        health = PlayerPrefs.GetFloat("maxHealthPlayer");
        //health = YandexGame.savesData.maxHealthPlayer;
        textHealth.text = health.ToString();

        speed = PlayerPrefs.GetInt("speedPlayer");
        //speed = YandexGame.savesData.speedPlayer;
        textSpeed.text = speed.ToString();

        //YandexGame.LoadProgress();
    }
}
