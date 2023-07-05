using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    public int cost; // ��������� ��������
    public UpgradeShop upgradeShop;
    public Button buttonBuy; // ������ �� ������ "������"
    public string DescriptionUpgrade;
    int upgradePlayer;

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
            Debug.Log("��� �����!!!");
        }
    }
}
