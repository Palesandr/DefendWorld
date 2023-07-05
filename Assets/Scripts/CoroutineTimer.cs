using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CoroutineTimer : MonoBehaviour
{
    [Header("врем€ раунда в секундах")]
    [SerializeField] private float time;
    public Text timerText;
    public GameObject scorePanel;
    public GameObject gameMenu;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textKill;    
    public TextMeshProUGUI textAllScore;
    public TextMeshProUGUI textAllKill;
    public static CoroutineTimer instance;
    public bool isFinallyLevel = false;

    [Header("–аунд со временем")]
    public bool isTime ;

    private float _timeLeft = 0f;

    private IEnumerator StartTimer()
    {
        while (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            UpdateTimeText();
            yield return null;
        }
    }

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        _timeLeft = time;

        if (isTime)
        {
            StartCoroutine(StartTimer());
        }  
    }

    private void UpdateTimeText()
    {
        if (_timeLeft < 0)
        {
            _timeLeft = 0;
            Time.timeScale = 0;
            scorePanel.SetActive(true);
            gameMenu.SetActive(false);
            textScore.text = GameManagers.scoreTemp.ToString();
            textKill.text = GameManagers.countEnemy.ToString();
            AudioManager.instance.Play("ScoreSound");
            if (isFinallyLevel == true)
            {
                textAllScore.text = PlayerPrefs.GetInt("finallyScore").ToString();
                textAllKill.text = PlayerPrefs.GetInt("finallyCountEnemy").ToString();
                
            }
            PlayerPrefs.SetInt("LevelID", SceneManager.GetActiveScene().buildIndex);
            PlayerPrefs.SetInt("isWinLevel", 1);
            PlayerPrefs.SetInt("isDead", 0);
            PlayerPrefs.SetInt("finallyScore", GameManagers.instance._finallyScore);
            PlayerPrefs.SetInt("money", GameManagers.scoreTemp + GameManagers.score);
            PlayerPrefs.Save();
        }

        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
}
