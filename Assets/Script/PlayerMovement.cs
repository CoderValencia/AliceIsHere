using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private float hitboxHeight;
    private float hitboxWidth;
    public LayerMask ground;
    public float jumpVelocity;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hitboxHeight = GetComponent<BoxCollider2D>().bounds.extents.y;
        hitboxWidth = GetComponent<BoxCollider2D>().bounds.extents.x;
    }

    void Update()
    {
        rb.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), rb.velocity.y);

        if (Input.GetButtonDown("Jump") && GroundCheck())
        {
            //very basic jump
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
        }
    }

    bool GroundCheck()
    {
        return Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - hitboxHeight), -Vector3.up, 0.02f, ground)
            || Physics2D.Raycast(new Vector3(transform.position.x - hitboxWidth, transform.position.y - hitboxHeight), -Vector3.up, 0.02f, ground)
            || Physics2D.Raycast(new Vector3(transform.position.x + hitboxWidth, transform.position.y - hitboxHeight), -Vector3.up, 0.02f, ground);
        //Make sure every ground object has layer set to ground when making terrain
    }
}
