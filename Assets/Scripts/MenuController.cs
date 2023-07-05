using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject game;


    public void PlayPressed()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //продолжить игру после победы
    public void ContinuePressed()
    {
        mainMenu.SetActive(false);
        game.SetActive(true);
        PlayerPrefs.SetInt("isWinLevel", 0);
        Time.timeScale = 1;
    }

    //метод продолжения игры после смерти
    public void CotinueAfterDie()
    {
        GameManagers.score = PlayerPrefs.GetInt("money");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("isDead", 0);
        PlayerPrefs.SetInt("isWinLevel", 0);
        Time.timeScale = 1;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.SetInt("isWinLevel", 0);
        Time.timeScale = 1;
    }
    

}
