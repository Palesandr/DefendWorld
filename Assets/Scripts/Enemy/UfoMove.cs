using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoMove : MonoBehaviour
{
    public string targetTag = "BonusShield"; // ��� ��������, � ������� ����� ���������
    private Rigidbody2D rb;
    public float speed; // �������� ��������
    

    public Transform target; // ������� ��������� ������


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //FindNearestTarget();
    }

    private void Update()
    {
        FindNearestTarget();


        if (target != null)
        {
            Vector2 direction = target.position - transform.position;
            rb.velocity = direction.normalized * speed;
        }
    }

    private void FindNearestTarget()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag); //������ �������� � ����� "BonusShield"
        float closestDistance = Mathf.Infinity;
        Transform closestTarget = null;

        foreach (GameObject targetObject in targets)
        {
            float distance = Vector2.Distance(transform.position, targetObject.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestTarget = targetObject.transform;
            }
        }

        target = closestTarget;
    }


}
