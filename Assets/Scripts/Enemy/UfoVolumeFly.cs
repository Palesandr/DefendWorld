using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoVolumeFly : MonoBehaviour
{
    GameObject enemy; // игровой объект, который слушает звук
    public GameObject soundObject; // игровой объект, который производит звук
    public float maxVolume = 1f; // максимальная громкость звука
    public float minDistance = 1f; // расстояние, на котором звук будет максимально громким
    public float maxDistance = 10f; // расстояние, на котором звук будет минимально громким

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
