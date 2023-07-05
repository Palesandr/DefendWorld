using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRocket : MonoBehaviour
{
    public Transform player;
    Rigidbody2D rb;
    public float speed = 4f;
    public float rotationSpeed = 120f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
        if (player != null)
        {
            Vector2 direction = (Vector2)player.position - rb.position;
            direction.Normalize();
            float angle = Vector3.Cross(direction, transform.up).z;
            rb.angularVelocity = -rotationSpeed * angle;
        }
    }

    /*void Update()
{
    transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.fixedDeltaTime);
    transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x) * Mathf.Rad2Deg - 90);
}*/

}
