using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
//using YG;

public class CoroutineTimer : MonoBehaviour
{
    [Header("время раунда в секундах")]
    [SerializeField] private float time;
    public TextMeshProUGUI timerText;
    public GameObject scorePanel;
    public GameObject gameMenu;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textKill;    
    public TextMeshProUGUI textAllScore;
    public TextMeshProUGUI textAllKill;
    public static CoroutineTimer instance;
    public bool isFinallyLevel = false;
    private AudioSource[] audioSources;
    public int _isPlay;
    int finallyS;
    int finallyE;

    [Header("Раунд со временем")]
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

    private void Awake()
    {
        audioSources = FindObjectsOfType<AudioSource>();
    }

    private void Start()
    {

        if (instance == null)
        {
            instance = this;
        }

        _timeLeft = time;
        _isPlay = 0;

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
            //_isPlay = 1; //после окончании раунда _isPlay = 1
            textScore.text = GameManagers.scoreTemp.ToString();
            textKill.text = GameManagers.countEnemy.ToString();
            StopAllSounds();
            AudioManager.instance.Play("ScoreSound1");

            /*if (isFinallyLevel == true)
            {
                textAllScore.text = PlayerPrefs.GetInt("finallyScore").ToString();
                textAllKill.text = PlayerPrefs.GetInt("finallyCountEnemy").ToString();
            }*/
            finallyS = GameManagers.instance._finallyScore + GameManagers.instance._roundFinallyScore;
            finallyE = GameManagers.instance._finallyCountEnemy + GameManagers.instance._roundFinallyCountEnemy;

            Debug.Log("END ROUND:");
            Debug.Log("Всего очков:" + finallyS);
            Debug.Log("Всего убито: " + finallyE);

             PlayerPrefs.SetInt("LevelID", SceneManager.GetActiveScene().buildIndex);
             PlayerPrefs.SetInt("nextLevelID", SceneManager.GetActiveScene().buildIndex + 1);
             PlayerPrefs.SetInt("isWinLevel", 1);
             PlayerPrefs.SetInt("isDead", 0);
             PlayerPrefs.SetInt("finallyScore", finallyS);
             PlayerPrefs.SetInt("finallyCountEnemy", finallyE);
             PlayerPrefs.SetInt("money", GameManagers.scoreTemp + GameManagers.score);
             PlayerPrefs.Save();

            /*YandexGame.savesData.LevelID = SceneManager.GetActiveScene().buildIndex;
            YandexGame.savesData.isWinLevel = 1;
            YandexGame.savesData.isDead = 0;
            YandexGame.savesData.finallyScore = GameManagers.instance._finallyScore;
            YandexGame.savesData.money = GameManagers.scoreTemp + GameManagers.score;
            YandexGame.SaveProgress();*/
        }

        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    public void StopAllSounds()
    {
        foreach (AudioSource audioSource in audioSources)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }

}
