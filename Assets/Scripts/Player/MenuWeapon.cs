using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using UnityEngine.InputSystem;

public class MenuWeapon : MonoBehaviour
{
    public GameObject Weapon1;
    public GameObject SelectWeapon1;
    public GameObject Weapon2;
    public GameObject SelectWeapon2;
    public TextMeshProUGUI textCountEnergy;
    public TextMeshProUGUI textCountBombWave;
    public GameObject Weapon3;
    public GameObject SelectWeapon3;
    //public TextMeshProUGUI textCountEnergy;

    // Update is called once per frame

    private void Start()
    {
        Fire.changeWeapon = 1;
    }
    void Update()
    {

        //активируем балстер
        if (Input.GetKeyDown(KeyCode.Alpha1))
        //if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            Fire.changeWeapon = 1;
            Weapon1.transform.Rotate(0, 0, 0.7f);
            SelectWeapon1.SetActive(true);
            SelectWeapon2.SetActive(false);
            SelectWeapon3.SetActive(false);
        }

        //активируем бомбы
        if (Input.GetKeyDown(KeyCode.Alpha2))
        //if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            Fire.changeWeapon = 2;
            Weapon2.transform.Rotate(0, 0, 0.7f);
            SelectWeapon1.SetActive(false);
            SelectWeapon2.SetActive(true);
            SelectWeapon3.SetActive(false);
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
        //if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            Fire.changeWeapon = 3;
            Weapon3.transform.Rotate(0, 0, 0.7f);
            SelectWeapon1.SetActive(false);
            SelectWeapon2.SetActive(false);
            SelectWeapon3.SetActive(true);
        }

        //количество снарядов при подбирании бонуса
        textCountEnergy.text = Fire.countEnergy.ToString();
        textCountBombWave.text = Fire.countBombWave.ToString();
    }

    private void FixedUpdate()
    {
        Weapon1.transform.Rotate(0, 0, 0.7f);
        Weapon2.transform.Rotate(0, 0, 0.7f);
        Weapon3.transform.Rotate(0, 0, 0.7f);
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
