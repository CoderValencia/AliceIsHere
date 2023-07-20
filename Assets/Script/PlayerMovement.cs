using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    float hitboxHeight;
    float hitboxWidth;
    public LayerMask ground;
    public float jumpVelocity;
    bool inJump;
    public float XVel;
    public float YVel;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hitboxHeight = GetComponent<BoxCollider2D>().bounds.extents.y;
        hitboxWidth = GetComponent<BoxCollider2D>().bounds.extents.x;
    }

    void Update()
    {
        XVel = speed * Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && GroundCheck())
        {
            YVel = jumpVelocity;
            inJump = true;
        }
    }

    void FixedUpdate()
    {
        if (inJump)
        {
            if(YVel > jumpVelocity / 2)
            {
                YVel -= 0.5f;
            } else
            {
                YVel -= 0.3f;
            }

            inJump = YVel > 0;

            if (!Input.GetButton("Jump"))
            {
                inJump = false;
                YVel = YVel/2.5f;
            }
        }

        if (!GroundCheck() && !inJump)
        {
            YVel -= 0.25f;
        }

        rb.velocity = new Vector2(XVel, YVel);
    }

    bool GroundCheck()
    {
        return Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - hitboxHeight), -Vector3.up, 0.02f, ground)
            || Physics2D.Raycast(new Vector3(transform.position.x - hitboxWidth, transform.position.y - hitboxHeight), -Vector3.up, 0.02f, ground)
            || Physics2D.Raycast(new Vector3(transform.position.x + hitboxWidth, transform.position.y - hitboxHeight), -Vector3.up, 0.02f, ground);
        //Make sure every ground object has layer set to ground when making terrain
    }
}
