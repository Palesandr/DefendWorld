using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindShieldBoss : MonoBehaviour
{
    public GameObject[] objectsArray; // ������ ��������
    private GameObject closestObject; // ��������� ������
    private float closestDistance = Mathf.Infinity; // ��������� �������� ����������

    private void Start()
    {
        objectsArray = GameObject.FindGameObjectsWithTag("BonusShield");
        FindClosestObject();
    }


    private void FindClosestObject()
    {
        // ���������� ��� ������� �� �������
        foreach (GameObject obj in objectsArray)
        {
            // ��������� ���������� ����� ���������� � ��������
            float distance = Vector2.Distance(transform.position, obj.transform.position);

            // ���� ������� ������ �����, ��� ���������� ��������� ������
            if (distance < closestDistance)
            {
                closestDistance = distance; // ��������� �������� ���������� ����������
                closestObject = obj; // ��������� ������ �� ��������� ������
                Debug.Log(closestObject);
                Debug.Log(closestDistance);
            }
        }
    }

   /* private void MoveTowardsObject()
    {
        if (closestObject != null)
        {
            // ������� ����������� � ���������� �������
            Vector3 direction = (closestObject.transform.position - transform.position).normalized;

            // ��������� � ���� ����������� � ������ ��������
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }*/
}
