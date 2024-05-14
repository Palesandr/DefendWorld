using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTime : MonoBehaviour
{
    public Sprite[] startImage = new Sprite[3];
    public Image imageTime;
    public GameObject gameMenu;
    public GameObject pauseMenu;


    private void Start()
     {
        
        StartCoroutine(startTimer());
     }

     IEnumerator startTimer()
     {
        //CoroutineTimer.instance._isPlay = 1;

        AudioManager.instance.Play("Timer");
        imageTime.sprite = startImage[0];
        yield return new WaitForSeconds(1f);
        AudioManager.instance.Play("Timer");
        imageTime.sprite = startImage[1];
        yield return new WaitForSeconds(1f);
        AudioManager.instance.Play("Timer");
        imageTime.sprite = startImage[2];
        yield return new WaitForSeconds(1f);
        AudioManager.instance.Play("TimerFinally");

        this.gameObject.SetActive(false);
        gameMenu.SetActive(true);
        pauseMenu.SetActive(true);
        CoroutineTimer.instance._isPlay = 0;
    }
}
