using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuWeapon : MonoBehaviour
{
    public GameObject Weapon1;
    public GameObject SelectWeapon1;
    public GameObject Weapon2;
    public GameObject SelectWeapon2;
    public TextMeshProUGUI textCountBomb;

// Update is called once per frame
void Update()
    {

        //активируем балстер
        /*if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Fire.changeWeapon = 1;
            Weapon1.transform.Rotate(0, 0, 0.7f);
            SelectWeapon1.SetActive(true);
            SelectWeapon2.SetActive(false);
        }

        //активируем бомбы
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Fire.changeWeapon = 2;
            Weapon2.transform.Rotate(0, 0, 0.7f);
            SelectWeapon1.SetActive(false);
            SelectWeapon2.SetActive(true);
        }*/

        textCountBomb.text = Fire.countBomb.ToString();
    }

    private void FixedUpdate()
    {
        Weapon1.transform.Rotate(0, 0, 0.7f);
        Weapon2.transform.Rotate(0, 0, 0.7f);
        /*if (Fire.changeWeapon == 1)
        {
            Weapon1.transform.Rotate(0, 0, 0.7f);
        }

        if (Fire.changeWeapon == 2)
        {
            Weapon2.transform.Rotate(0, 0, 0.7f);
        }*/
    }
}
