using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShieldBarPlayer : MonoBehaviour
{
    public Image shieldBar;

    public TextMeshProUGUI textShield;


    void Update()
    {
        shieldBar.fillAmount = Shield.shieldHealth / Shield.maxHP;
        textShield.text = shieldBar.fillAmount.ToString();
        //textShield.text = PlayerController.maxHP.ToString();
    }
}
