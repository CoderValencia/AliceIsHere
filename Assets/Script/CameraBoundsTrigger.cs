using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundsTrigger : MonoBehaviour
{
    public Vector2 topRightCorner;
    public Vector2 bottomLeftCorner;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Camera.main.gameObject.GetComponent<CameraMove>().topRightCorner = topRightCorner;
            Camera.main.gameObject.GetComponent<CameraMove>().bottomLeftCorner = bottomLeftCorner;
        }
    }
}
