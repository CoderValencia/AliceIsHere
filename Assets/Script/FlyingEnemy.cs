using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    Vector2 home;
    int AIMode = 0;
    public bool moveVertical;
    public bool moveHorizontal;
    public float TimeBeforeTurn;
    float distance = 0;
    Rigidbody2D rb;
    bool direction;
    public float speed;

    void Awake()
    {
        home = transform.position;
        distance = TimeBeforeTurn*25;
        rb = GetComponent<Rigidbody2D>();
    }
    
    void FixedUpdate()
    {
        distance++;
        if(distance > TimeBeforeTurn*50)
        {
            distance = 0;
            direction = !direction;
        }
        if (moveHorizontal)
        {
            if(direction)
                rb.velocity = new Vector2(speed, rb.velocity.y);
            else
                rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        if (moveVertical)
        {
            if (direction)
                rb.velocity = new Vector2(rb.velocity.x, speed);
            else
                rb.velocity = new Vector2(rb.velocity.x, -speed);
        }
    }
}
