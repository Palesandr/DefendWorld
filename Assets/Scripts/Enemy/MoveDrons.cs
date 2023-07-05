using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDrons : MonoBehaviour
{
    Transform player;
    public float speed = 4f;
    float dist;
    public float distance = 5f;

    Rigidbody2D rb;



    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, Mathf.Atan2(player.position.y - transform.position.y, player.position.x - transform.position.x) * Mathf.Rad2Deg - 90);

            Vector3 direction = transform.position - player.position;

            dist = Vector3.Distance(player.position, transform.position);

            transform.RotateAround(player.position, Vector3.forward, 20 * Time.fixedDeltaTime);
            //transform.position = (transform.position - player.position).normalized * 3f + player.position * Time.fixedDeltaTime;
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.fixedDeltaTime);


            if (dist <= 7f)
            {
                if (direction.magnitude < distance)
                {
                    transform.position = player.position + direction.normalized * distance;
                }
            }
        }

    }
}
