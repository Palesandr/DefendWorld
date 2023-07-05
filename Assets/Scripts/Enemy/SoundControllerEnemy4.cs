using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControllerEnemy4 : MonoBehaviour
{
    public AudioClip soundClip; // звуковой файл, который будет воспроизводиться
    public float maxDistance = 12f; // максимальная дистанция, на которой слышен звук
    public float volume = 0.8f; // громкость звука
    GameObject player;

    private AudioSource audioSource;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = GetComponent<AudioSource>(); 
        audioSource.clip = soundClip;

        audioSource.Play();
    }

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position); // расстояние до камеры
            float volumeMultiplier = Mathf.Clamp(1 - distanceToPlayer / maxDistance, 0, 1); // коэффициент громкости
            audioSource.volume = volume * volumeMultiplier; // изменяем громкость
        }
    }
}
