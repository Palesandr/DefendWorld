using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeShop : MonoBehaviour
{
    public int money; // количество ваших денег при старте игры
    public TextMeshProUGUI textMoney; // ссылка на текст на игровой сцене, в котором отображено количество денег.
    public Upgrade[] upgrade; // ссылки на все ваши скины (объекты Scin1, Scin2, Scin3)

    private void Update()
    {
        if (PlayerPrefs.HasKey("money"))
        {
            money = PlayerPrefs.GetInt("money");
        }

    }
}
