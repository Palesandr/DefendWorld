using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skins : MonoBehaviour
{
    public int cost; // ��������� �����
    public int scinID; // id �����
    public bool isBuy; // ������ �� ����?
    public bool isSelected; // ����������� �� ����?

    public Button buttonBuy; // ������ �� ������ "������"
    public Button buttonSelect; // ������ �� ������ "���������"
    public SkinsShop skinShop; // ������ �� ������ ScinShop ��������, ������� ��������� �� ������� Canvas

    public void Buy()
    {
        if (skinShop.money >= cost)
        {
            skinShop.money -= cost;
            skinShop.textMoney.text = "�����: " + skinShop.money.ToString();
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
