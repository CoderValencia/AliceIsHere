using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public int damage = 1;

    private void OnCollisionStay2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("Player") && c.gameObject.GetComponent<PlayerHealthSystem>().IFrames == 0)
        {
            c.gameObject.GetComponent<PlayerHealthSystem>().health -= damage;
            c.gameObject.GetComponent<PlayerHealthSystem>().IFrames = c.gameObject.GetComponent<PlayerHealthSystem>().MaxIFrames;
        }
    }

    private void OnTriggerStay2D(Collider2D c)
    {
        if (c.gameObject.CompareTag("Player") && c.gameObject.GetComponent<PlayerHealthSystem>().IFrames == 0)
        {
            c.gameObject.GetComponent<PlayerHealthSystem>().health -= damage;
            c.gameObject.GetComponent<PlayerHealthSystem>().IFrames = c.gameObject.GetComponent<PlayerHealthSystem>().MaxIFrames;
        }
    }
}
