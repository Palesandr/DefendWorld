using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
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

    void Start()
    {

        sumScore = PlayerPrefs.GetInt("money");
        //sumScore = sumScore + GameManagers.score;

        //показать кнопку "Продолжить" на главном меню
        isDead = PlayerPrefs.GetInt("isDead");
        isWinLevel = PlayerPrefs.GetInt("isWinLevel");

        //если победа
        if (isWinLevel == 1)
        {
            continueButton.gameObject.SetActive(true);
        }

        //если убит
        if (isDead == 1)
        {
            continueButton.gameObject.SetActive(true);
        }

        if ((isWinLevel == 0) && (isDead == 0))
        {
            continueButton.gameObject.SetActive(false);
        }

        if (PlayerPrefs.HasKey("money"))
        {
            

            /*if (sumScore >= menuManager.priceUpgrade)
            {
                buttonShield.interactable = true;
            }
            else { buttonShield.interactable = false; }*/
        }

                //Debug.Log("score: " + score);
                //Debug.Log("isDead: " + isDead);


                //Debug.Log("isWinLevel: " + isWinLevel);
    }

    private void Update() 
    {
        sumScore = PlayerPrefs.GetInt("money");
        textScore.text = sumScore.ToString();

        maxShield = PlayerPrefs.GetFloat("maxHealthShield"); 
        textShield.text = maxShield.ToString();

        health = PlayerPrefs.GetFloat("maxHealthPlayer");
        textHealth.text = health.ToString();

        speed = PlayerPrefs.GetInt("speedPlayer");
        textSpeed.text = speed.ToString();
    }
}
