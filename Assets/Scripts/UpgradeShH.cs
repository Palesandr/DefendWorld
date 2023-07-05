using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeShH : MonoBehaviour
{
    public int cost; // стоимость апгрейда
    public UpgradeShop upgradeShop;
    public Button buttonBuy; // ссылка на кнопку "купить"
    public string DescriptionUpgrade;
    float upgradePlayer;

    public void Buy()
    {
        if (upgradeShop.money >= cost)
        {
            //if (DescriptionUpgrade == "speedPlayer")
            //{
                upgradePlayer = PlayerPrefs.GetFloat(DescriptionUpgrade);
            //}
            //else
            //{
            //    upgradePlayer = PlayerPrefs.GetFloat(DescriptionUpgrade);
            //}
            upgradePlayer += 1;

            upgradeShop.money -= cost;
            PlayerPrefs.SetInt("money", upgradeShop.money);
            PlayerPrefs.SetFloat(DescriptionUpgrade, upgradePlayer);
            PlayerPrefs.Save();
        }
        else {
            Debug.Log("нет денег!!!");
        }
    }
}
