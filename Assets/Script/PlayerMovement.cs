using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

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
    bool facingLeft;
    Animator a;
    AudioSource au;
    //public bool canJump;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hitboxHeight = GetComponent<BoxCollider2D>().bounds.extents.y;
        hitboxWidth = GetComponent<BoxCollider2D>().bounds.extents.x;
        a = GetComponent<Animator>();
        //canJump = true;
        au = GetComponent<AudioSource>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        bool ground = GroundCheck();

        if (ground && YVel < 0)
        {
            YVel = 0;
        }

        XVel = speed * moveInput;
        if(moveInput > 0)
        {
            facingLeft = false;
        } else if (moveInput < 0)
        {
            facingLeft = true;
        }

        if (facingLeft)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        } else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetButtonDown("Jump") && ground )
        {
            YVel = jumpVelocity;
            inJump = true;
        }
        
        a.SetBool("IsGrounded", ground);


        if (!au.isPlaying && Mathf.Abs(XVel)>0.1f)
        {
            au.Play();
            au.loop = true;
        }
        if (!(Mathf.Abs(XVel) > 0.1f))
        {
            au.loop = false;
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

        a.SetBool("IsJumping", inJump);
        a.SetBool("IsMoving", Mathf.Abs(XVel) > 0.01f);
        transform.position = new Vector3(transform.position.x, transform.position.y, -2);
        rb.velocity = new Vector2(XVel, YVel);
    }

    bool GroundCheck()
    {
        return Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - hitboxHeight + GetComponent<Collider2D>().offset.y), -Vector3.up, 0.02f, ground)
            || Physics2D.Raycast(new Vector3(transform.position.x - hitboxWidth + GetComponent<Collider2D>().offset.x * transform.localScale.x, transform.position.y - hitboxHeight + GetComponent<Collider2D>().offset.y), -Vector3.up, 0.02f, ground)
            || Physics2D.Raycast(new Vector3(transform.position.x + hitboxWidth + GetComponent<Collider2D>().offset.x * transform.localScale.x, transform.position.y - hitboxHeight + GetComponent<Collider2D>().offset.y), -Vector3.up, 0.02f, ground);
        //Make sure every ground object has layer set to ground when making terrain
    }
}
