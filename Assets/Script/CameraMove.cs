using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    GameObject target;
    public float speed = 1;
    public Vector2 topRightCorner;
    public Vector2 bottomLeftCorner;
    void Awake()
    {
        target = FindObjectOfType<PlayerMovement>().gameObject;
    }
    void FixedUpdate()
    {
        transform.position = Vector2.Lerp(transform.position, target.transform.position, Time.deltaTime * Vector2.Distance(transform.position, target.transform.position) * speed);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        if (transform.position.x > topRightCorner.x)
        {
            transform.position = new Vector3(topRightCorner.x, transform.position.y, transform.position.z);
        }
        if (transform.position.y > topRightCorner.y)
        {
            transform.position = new Vector3(transform.position.x, topRightCorner.y, transform.position.z);
        }
        if (transform.position.x < bottomLeftCorner.x)
        {
            transform.position = new Vector3(bottomLeftCorner.x, transform.position.y, transform.position.z);
        }
        if (transform.position.y < bottomLeftCorner.y)
        {
            transform.position = new Vector3(transform.position.x, bottomLeftCorner.y, transform.position.z);
        }
    }
}
