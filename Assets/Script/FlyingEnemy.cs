using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    Vector2 home;
    int AIMode = 0;
    public bool attackPlayer;
    public float agroRange = 4;
    public bool moveVertical;
    public bool moveHorizontal;
    public float TimeBeforeTurn;
    float distance = 0;
    Rigidbody2D rb;
    bool direction;
    public float speed;
    int attackCounter;
    GameObject player;
    Vector2 attackTarget;
    Vector2 initialAttackPosition;

    void Awake()
    {
        home = transform.position;
        distance = TimeBeforeTurn*25;
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }
    
    void FixedUpdate()
    {
        //AIMode key
        //0: Patroling
        //1: Preparing to attack
        //2: Charging at player
        //3: Return from charge
        //4: Return to home
        if(AIMode == 0)
        {
            distance++;
            if (distance > TimeBeforeTurn * 50)
            {
                distance = 0;
                direction = !direction;
            }
            if (moveHorizontal)
            {
                if (direction)
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

            
            if(attackPlayer && Vector2.Distance(transform.position, player.transform.position) < agroRange){
                AIMode = 1;
                attackCounter = 40;
                rb.velocity = Vector2.zero;
            }
        }
        else if (AIMode == 1)
        {
            attackCounter--;
            if(attackCounter == 0)
            {
                AIMode = 2;
                attackTarget = player.transform.position;
                initialAttackPosition = transform.position;
            }
        }
        else if (AIMode == 2)
        {
            rb.velocity = 1.5f * speed * (attackTarget - (Vector2)transform.position).normalized;
            if(Vector2.Distance(transform.position, attackTarget) < 0.2f)
            {
                AIMode = 3;
            }
        }
        else if (AIMode == 3)
        {
            rb.velocity = 1.5f * speed * (initialAttackPosition - (Vector2)transform.position).normalized;
            if (Vector2.Distance(transform.position, initialAttackPosition) < 0.2f)
            {
                AIMode = 4;
            }
        }
        else if (AIMode == 4)
        {
            rb.velocity = speed * (home - (Vector2)transform.position).normalized;
            if (Vector2.Distance(transform.position, home) < 0.1f)
            {
                AIMode = 0;
                distance = TimeBeforeTurn * 25;
                transform.position = home;
                if (moveHorizontal)
                    direction = player.transform.position.x < home.x;
                else if (moveVertical){
                    direction = player.transform.position.y < home.y;
                }
            }
        }
        
    }
}
