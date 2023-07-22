using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    public int health = 3;
    public int maxHealth = 3;
    public Vector2 respawnPos;
    public int MaxIFrames = 50;
    public int IFrames = 0;
    int deathCounter = 0;
    float tempsize;

    private void FixedUpdate()
    {
        if(health <= 0 && deathCounter == 0)
        {
            Die();
        }
        if(IFrames > 0)
        {
            IFrames--;
        }
        if (deathCounter != 0)
        {
            deathCounter++;
        }
        if(deathCounter == 90)
        {
            Respawn();
        }
    }

    private void Update()
    {
        //flicker effect
        if (GetComponent<SpriteRenderer>().color == Color.clear)
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        else if (IFrames > 0)
        {
            GetComponent<SpriteRenderer>().color = Color.clear;
        }
    }

    public void Die()
    {
        Camera.main.gameObject.GetComponent<CameraFade>().StartFade();
        GetComponent<Animator>().SetBool("IsDead", true);
        deathCounter = 1;
        GetComponent<PlayerMovement>().enabled = false;
        tempsize = GetComponent<BoxCollider2D>().size.y;
        GetComponent<BoxCollider2D>().size = new Vector2(GetComponent<BoxCollider2D>().size.x, 0.25f);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
    }

    public void Respawn()
    {
        Camera.main.gameObject.GetComponent<CameraFade>().EndFade();
        GetComponent<Animator>().SetBool("IsDead", false);
        transform.position = respawnPos;
        GetComponent<PlayerMovement>().enabled = true;
        GetComponent<PlayerMovement>().XVel = 0;
        GetComponent<PlayerMovement>().YVel = 0;
        IFrames = MaxIFrames;
        health = maxHealth;
        deathCounter = 0;
        GetComponent<BoxCollider2D>().size = new Vector2(GetComponent<BoxCollider2D>().size.x, tempsize);
    }
}
