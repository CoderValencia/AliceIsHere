using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliceParamaterTrigger : MonoBehaviour
{
    public float jumpHeight;
    public float speed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().jumpVelocity = jumpHeight;
            collision.gameObject.GetComponent<PlayerMovement>().speed = speed;
        }
    }
}
