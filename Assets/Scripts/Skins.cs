using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skins : MonoBehaviour
{
    public int cost; // стоимость скина
    public int scinID; // id скина
    public bool isBuy; // куплен ли скин?
    public bool isSelected; // активирован ли скин?

    public Button buttonBuy; // ссылка на кнопку "купить"
    public Button buttonSelect; // ссылка на кнопку "применить"
    public SkinsShop skinShop; // ссылка на скрипт ScinShop магазина, который находится на объекте Canvas

    public void Buy()
    {
        if (skinShop.money >= cost)
        {
            skinShop.money -= cost;
            skinShop.textMoney.text = "Монет: " + skinShop.money.ToString();
            isBuy = true;
            buttonBuy.gameObject.SetActive(false);
            buttonSelect.gameObject.SetActive(true);
            PlayerPrefs.SetInt("money", skinShop.money);
            PlayerPrefs.SetInt("buy" + scinID, 1);
            PlayerPrefs.Save();
        }
    }

    public void Select()
    {
        skinShop.skins[skinShop.activeScinID].buttonSelect.gameObject.SetActive(true);
        skinShop.skins[skinShop.activeScinID].isSelected = false;
        skinShop.activeScinID = scinID;
        isSelected = true;
        buttonSelect.gameObject.SetActive(false);
        PlayerPrefs.SetInt("skinsID", scinID);
        PlayerPrefs.Save();
    }

}
