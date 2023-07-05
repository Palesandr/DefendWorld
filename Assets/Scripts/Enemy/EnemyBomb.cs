using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBomb : MonoBehaviour
{
    public int damage = 5;
    public LayerMask whatIsSolid;
    GameObject _player;
    float dist;
    public Component[] circleCollider2D;
    public GameObject hitEffect;

    private void Start()
    {
        circleCollider2D = GetComponentsInChildren<CircleCollider2D>();

        _player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(EnableCollider());

    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //здесь делаем то, когда входим в зону бомбы
        PlayerController player = hitInfo.GetComponent<PlayerController>();
        Shield shield = hitInfo.GetComponent<Shield>();
        Bullet bullet = hitInfo.GetComponent<Bullet>();

        if (player != null)
        {
            //Debug.Log(hitInfo.name);
            player.TakeDamage(damage);
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.2f);
            Destroy(gameObject);
            AudioManager.instance.Play("Bomb");
        }

        if (shield != null)
        {
            //Debug.Log(hitInfo.name);
            shield.TakeDamage(damage);
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.2f);
            Destroy(gameObject);
            AudioManager.instance.Play("Bomb");
        }

        if (bullet != null)
        {
            Debug.Log(hitInfo.name);
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.2f);
            Destroy(gameObject);
            AudioManager.instance.Play("Bomb");
        }

    }

    private void FixedUpdate()
    {
        if (_player != null)
        {
            dist = Vector3.Distance(_player.transform.position, transform.position);

            if (dist < 7)
            {
                transform.Rotate(0, 0, 5f);
            }

            if (dist < 5)
            {
                transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, 3 * Time.fixedDeltaTime);
                transform.Rotate(0, 0, 8f);
            }
        }
    }

    //вклчаем коллайдер через 3 сек
    private IEnumerator EnableCollider()
    {
        yield return new WaitForSeconds(1f);
        foreach (CircleCollider2D circle in circleCollider2D)
            circle.enabled = true;
    }
}
