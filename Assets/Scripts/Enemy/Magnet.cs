using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public string targetTag = "Player"; // Тег объектов для притягивания
    public float forceStrength = 1f; // Сила притяжения магнита
    public float radius = 20f; // Радиус действия магнита

    private CircleCollider2D circleCollider;

    void Start()
    {
        // Добавляем компонент CircleCollider2D к магниту
        circleCollider = gameObject.AddComponent<CircleCollider2D>();
        circleCollider.radius = radius;
        circleCollider.isTrigger = true;
    }

    void Update()
    {
        // Получаем все коллайдеры 2D внутри радиуса действия магнита
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D target in targets)
        {
            // Если тег объекта соответствует целевому тегу
            if (target.CompareTag(targetTag))
            {
                // Притягиваем объект к магниту
                Vector2 direction = transform.position - target.transform.position;
                target.GetComponent<Rigidbody2D>().AddForce(direction.normalized * forceStrength * Time.deltaTime);
                //AudioManager.instance.Play("Magnit");
            }
        }
    }

    // Отображаем радиус магнита в окне Scene
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
