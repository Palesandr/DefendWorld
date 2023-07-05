using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkinsShop : MonoBehaviour
{
    public int money; // количество ваших денег при старте игры
    public TextMeshProUGUI textMoney; // ссылка на текст на игровой сцене, в котором отображено количество денег.
    public Skins[] skins; // ссылки на все ваши скины (объекты Scin1, Scin2, Scin3)
    public int activeScinID = 0; // номер скина, который куплен и активирован изначально

    private void Start()
    {
        //PlayerPrefs.DeleteAll();

        if (PlayerPrefs.HasKey("money"))
        {
            money = PlayerPrefs.GetInt("money");
        }

        if (PlayerPrefs.HasKey("skinsID"))
        {
            activeScinID = PlayerPrefs.GetInt("skinsID");
        }
        skins[activeScinID].isBuy = true;
        skins[activeScinID].isSelected = true;
        PlayerPrefs.SetInt("buy" + activeScinID, 1);
        PlayerPrefs.SetInt("skinsID", activeScinID);

        textMoney.text = "Монет: " + money.ToString();

        for (int j = 0; j < skins.Length; j++)
        {

            if (PlayerPrefs.GetInt("buy" + j) == 1)
            {
                skins[j].isBuy = true;
            }

            if (skins[j].isBuy == true)
            {
                skins[j].buttonBuy.gameObject.SetActive(false);
            }

            if (skins[j].isSelected == true || skins[j].isBuy == false)
            {
                skins[j].buttonSelect.gameObject.SetActive(false);
            }
        }
    }
}
