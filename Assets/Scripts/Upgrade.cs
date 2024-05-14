using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    public int cost; // стоимость апгрейда
    public UpgradeShop upgradeShop;
    public Button buttonBuy; // ссылка на кнопку "купить"
    public string DescriptionUpgrade;
    int upgradePlayer;
    int _levelID;
    public TextMeshProUGUI costSpeed;

    private void Update()
    {
        _levelID = PlayerPrefs.GetInt("LevelID");

        switch (_levelID)
        {
            case 1:
                cost = 200;
                break;
            case 2:
                cost = 210;
                break;
            case 3:
                cost = 220;
                break;
            case 4:
                cost = 230;
                break;
            case 5:
                cost = 240;
                break;
            case 6:
                cost = 300;
                break;
            case 7:
                cost = 310;
                break;
            case 8:
                cost = 320;
                break;
            case 9:
                cost = 330;
                break;
            case 10:
                cost = 340;
                break;
            case 11:
                cost = 400;
                break;
            case 12:
                cost = 450;
                break;
            case 13:
                cost = 500;
                break;
            case 14:
                cost = 600;
                break;
            default:
                break;
        }

        costSpeed.text = cost.ToString();

    }
    public void Buy()
    {
        if (upgradeShop.money >= cost)
        {
            //if (DescriptionUpgrade == "speedPlayer")
            //{
                upgradePlayer = PlayerPrefs.GetInt(DescriptionUpgrade);
            //}
            //else
            //{
            //    upgradePlayer = PlayerPrefs.GetFloat(DescriptionUpgrade);
            //}
            upgradePlayer += 1;

            upgradeShop.money -= cost;
            PlayerPrefs.SetInt("money", upgradeShop.money);
            PlayerPrefs.SetInt(DescriptionUpgrade, upgradePlayer);
            PlayerPrefs.Save();
        }
        else {
            Debug.Log("нет денег!!!");
        }
    }
}
