using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SoundOnOff : MonoBehaviour
{
    public GameObject[] soundButton;


    private void Start()
    {


        if (PlayerPrefs.GetInt("isSound") == 1)
        {
            SoundOff();
            
        }

        if (PlayerPrefs.GetInt("isSound") == 0)
        {
            SoundOn();
        }
    }
    public void SoundOn()
    {
        soundButton[0].SetActive(false);
        soundButton[1].SetActive(true);

        //AudioListener.pause = true;
        AudioListener.volume = 0;
        PlayerPrefs.SetInt("isSound", 0);
        //UnityEngine.Debug.Log("SoundOn");
    }

    public void SoundOff()
    {
        soundButton[0].SetActive(true);
        soundButton[1].SetActive(false);
        //AudioListener.pause = false;
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("isSound", 1);
        //UnityEngine.Debug.Log("SoundOff");
    }
}
