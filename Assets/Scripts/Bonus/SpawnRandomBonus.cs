using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomBonus : MonoBehaviour
{
    public GameObject randomBonus;
    float maxX, minX, maxY, minY;
    float nextSpawnTime;
    public float beginTime;
    public float endTime;
    public float sizeRandomBonusX, sizeRandomBonusY;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector2(sizeRandomBonusX, sizeRandomBonusY));
    }
    private void Start()
    {
        maxX = transform.position.x + transform.localScale.x / 2;
        minX = transform.position.x - transform.localScale.x / 2;

        maxY = transform.position.y + transform.localScale.y / 2;
        minY = transform.position.y - transform.localScale.y / 2;
    }

    private void Update()
    {

        Spawn();
    }

    private void Spawn()
    {
        if (Time.time > nextSpawnTime)
        {
            Vector3 spawmPos = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), transform.position.z);
            Instantiate(randomBonus, spawmPos, Quaternion.identity);

            nextSpawnTime = Time.time + Random.Range(beginTime, endTime);
        }
    }
}
