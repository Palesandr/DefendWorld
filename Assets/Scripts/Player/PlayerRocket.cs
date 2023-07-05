using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRocket : MonoBehaviour
{
    public GameObject enemy;

    void Start()
    {
        
        enemy = GameObject.Find("Enemy1");
    }

    void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, enemy.transform.position, 10 * Time.fixedDeltaTime);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(enemy.transform.position.y - transform.position.y, enemy.transform.position.x - transform.position.x) * Mathf.Rad2Deg - 90);
    }

}
