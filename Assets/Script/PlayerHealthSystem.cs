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

    private void FixedUpdate()
    {
        if(health <= 0)
        {
            Die();
        }
        if(IFrames > 0)
        {
            IFrames--;
        }
    }

    public void Die()
    {
        transform.position = respawnPos;
        GetComponent<PlayerMovement>().XVel = 0;
        GetComponent<PlayerMovement>().YVel = 0;
        IFrames = MaxIFrames;
        health = maxHealth;
    }
}