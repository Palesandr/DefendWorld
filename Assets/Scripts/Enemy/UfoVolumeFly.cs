using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoVolumeFly : MonoBehaviour
{
    GameObject enemy; // ������� ������, ������� ������� ����
    public GameObject soundObject; // ������� ������, ������� ���������� ����
    public float maxVolume = 1f; // ������������ ��������� �����
    public float minDistance = 1f; // ����������, �� ������� ���� ����� ����������� �������
    public float maxDistance = 10f; // ����������, �� ������� ���� ����� ���������� �������

    private AudioSource audioSource;

    private void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        audioSource = enemy.GetComponent<AudioSource>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(enemy.transform.position, transform.position);
        float volume = Mathf.Clamp01((maxDistance - distance) / (maxDistance - minDistance)) * maxVolume;
        audioSource.volume = volume;
    }
}
