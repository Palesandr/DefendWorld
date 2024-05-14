using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject game;
    int _isWin;
    int _isPlay;
 

    void Update()
    {
        _isWin = PlayerPrefs.GetInt("isWinLevel");
        _isPlay = CoroutineTimer.instance._isPlay;

        if (_isWin == 0)
        {
            //if (Keyboard.current.escapeKey.wasPressedThisFrame)
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Time.timeScale = 0;
                mainMenu.SetActive(true);
                game.SetActive(false);
            }
        }
       

       
    }
}
