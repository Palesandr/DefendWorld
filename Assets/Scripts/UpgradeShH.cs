using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.InteropServices;

public class UpgradeShH : MonoBehaviour
{
    public int cost; // стоимость апгрейда

    public UpgradeShop upgradeShop;
    public Button buttonBuy; // ссылка на кнопку "купить"
    public string DescriptionUpgrade;
    float upgradePlayer;
    int _levelID;
    float _levelUpdate;

    public TextMeshProUGUI costUpdate;



    private void Update()
    {
        _levelID = PlayerPrefs.GetInt("LevelID");
        _levelUpdate = PlayerPrefs.GetFloat(DescriptionUpgrade);
        //PlayerPrefs.SetInt("speedPlayer", 8);
        //Debug.Log(DescriptionUpgrade + ": " + _levelUpdate);
      
        switch (_levelUpdate)
        {
            case 10: 
            case 11: 
            case 12: 
                cost = 120;
                break;
            case 13:
            case 14:
                cost = 150;
                break;
            case 15:
            case 16:
                cost = 170;
                break;
            case 17:
            case 18:
            case 19:
                cost = 200;
                break;
            case 20:
            case 21:
            case 22:
                cost = 220;
                break;
            case 23:
            case 24:
                cost = 250;
                break;
            case 25:
            case 26: 
            case 27:
            case 28:
            case 29:
                cost = 270;
                break;
            case 30:
            case 31:
                cost = 300;
                break;
            case 32:
            case 33:
            case 34:
                cost = 350;
                break;
            case > 35:
                cost = 400;
                break;
            /*default:
                cost = 700;
                break;*/
        }

        costUpdate.text = cost.ToString();

    }
    void upCostShield()
    {

    }

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
