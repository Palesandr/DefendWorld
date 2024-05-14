using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public string targetTag = "Player"; // ��� �������� ��� ������������
    public float forceStrength = 1f; // ���� ���������� �������
    public float radius = 20f; // ������ �������� �������

    private CircleCollider2D circleCollider;

    void Start()
    {
        // ��������� ��������� CircleCollider2D � �������
        circleCollider = gameObject.AddComponent<CircleCollider2D>();
        circleCollider.radius = radius;
        circleCollider.isTrigger = true;
    }

    void Update()
    {
        // �������� ��� ���������� 2D ������ ������� �������� �������
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, radius);

        foreach (Collider2D target in targets)
        {
            // ���� ��� ������� ������������� �������� ����
            if (target.CompareTag(targetTag))
            {
                // ����������� ������ � �������
                Vector2 direction = transform.position - target.transform.position;
                target.GetComponent<Rigidbody2D>().AddForce(direction.normalized * forceStrength * Time.deltaTime);
                //AudioManager.instance.Play("Magnit");
            }
        }
    }

    // ���������� ������ ������� � ���� Scene
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
