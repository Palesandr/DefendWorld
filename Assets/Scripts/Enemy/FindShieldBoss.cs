using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindShieldBoss : MonoBehaviour
{
    public GameObject[] objectsArray; // Массив объектов
    private GameObject closestObject; // Ближайший объект
    private float closestDistance = Mathf.Infinity; // Начальное значение расстояния

    private void Start()
    {
        objectsArray = GameObject.FindGameObjectsWithTag("BonusShield");
        FindClosestObject();
    }


    private void FindClosestObject()
    {
        // Перебираем все объекты из массива
        foreach (GameObject obj in objectsArray)
        {
            // Вычисляем расстояние между персонажем и объектом
            float distance = Vector2.Distance(transform.position, obj.transform.position);

            // Если текущий объект ближе, чем предыдущий ближайший объект
            if (distance < closestDistance)
            {
                closestDistance = distance; // Обновляем значение ближайшего расстояния
                closestObject = obj; // Обновляем ссылку на ближайший объект
                Debug.Log(closestObject);
                Debug.Log(closestDistance);
            }
        }
    }

   /* private void MoveTowardsObject()
    {
        if (closestObject != null)
        {
            // Находим направление к ближайшему объекту
            Vector3 direction = (closestObject.transform.position - transform.position).normalized;

            // Двигаемся в этом направлении с учетом скорости
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }*/
}
