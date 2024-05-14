using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;
using UnityEngine.UI;
using TMPro;

public class RewardAdsManager : MonoBehaviour
{
    public YandexGame sdk;
    public int coins;
    public TextMeshProUGUI coinText;
    public GameObject btnReward;
    int sumScore;

    private void Start()
    {
        btnReward = GameObject.Find("CoinForReklama");
    }

    private void Update()
    {
        coins = PlayerPrefs.GetInt("money");
        //YandexGame.LoadProgress();
    }

    public void AdButton()
    {
        sdk._RewardedShow(1);
        btnReward.SetActive(false);
        PlayerPrefs.SetInt("isReklama", 0); //0 - не показываем рекламу, 1 - показываем рекламу
        PlayerPrefs.Save();
    }

    public void AdButtonCul()
    {
        coins += 100;
        //sumScore += 100;
        coinText.text = coins.ToString();
        PlayerPrefs.SetInt("money", coins);
        //YandexGame.savesData.money = coins;
        //YandexGame.SaveProgress();
    }

}
