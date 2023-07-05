using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControllerEnemy4 : MonoBehaviour
{
    public AudioClip soundClip; // �������� ����, ������� ����� ����������������
    public float maxDistance = 12f; // ������������ ���������, �� ������� ������ ����
    public float volume = 0.8f; // ��������� �����
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
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position); // ���������� �� ������
            float volumeMultiplier = Mathf.Clamp(1 - distanceToPlayer / maxDistance, 0, 1); // ����������� ���������
            audioSource.volume = volume * volumeMultiplier; // �������� ���������
        }
    }
}
