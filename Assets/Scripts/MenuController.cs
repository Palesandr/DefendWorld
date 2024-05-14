using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using YG;

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

    //���������� ���� ����� ������
    public void ContinuePressed()
    {
        mainMenu.SetActive(false);
        game.SetActive(true);
        PlayerPrefs.SetInt("isWinLevel", 0);
        //YandexGame.savesData.isWinLevel = 0;
        Time.timeScale = 1;
    }

    //����� ����������� ���� ����� ������
    public void CotinueAfterDie()
    {
        GameManagers.score = PlayerPrefs.GetInt("money");
        //GameManagers.score = YandexGame.savesData.money;
        //YandexGame.LoadProgress();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetInt("isDead", 0);
        PlayerPrefs.SetInt("isWinLevel", 0); 

        /*YandexGame.savesData.isDead = 0;
        YandexGame.savesData.isWinLevel = 0;
        YandexGame.SaveProgress();*/

        Time.timeScale = 1;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.SetInt("isWinLevel", 0);
        //YandexGame.savesData.isWinLevel = 0;
        //YandexGame.SaveProgress();
        Time.timeScale = 1;
    }
    

}
