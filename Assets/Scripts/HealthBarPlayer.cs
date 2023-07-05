using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarPlayer : MonoBehaviour
{
    public Image healthBar;
    public TextMeshProUGUI textHealth;


    void Update()
    {
        healthBar.fillAmount = PlayerController.health / PlayerController.maxHP;
        //textHealth.text = healthBar.fillAmount.ToString();
        textHealth.text = PlayerController.maxHP.ToString();
    }
}
