using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SoundOnOff : MonoBehaviour
{
    public GameObject[] soundButton;

    public void SoundOn()
    {
        soundButton[0].SetActive(false);
        soundButton[1].SetActive(true);
        AudioListener.pause = true;
        UnityEngine.Debug.Log("SoundOn");
    }

    public void SoundOff()
    {
        soundButton[0].SetActive(true);
        soundButton[1].SetActive(false);
        AudioListener.pause = false;
        UnityEngine.Debug.Log("SoundOff");
    }
}
