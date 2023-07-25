using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RavenAnimation : MonoBehaviour
{
    public GameObject p;

    private void Awake()
    {
        p = FindObjectOfType<PlayerMovement>().gameObject;
    }
    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, p.transform.position) < 8f)
        {
            GetComponent<Animator>().enabled = true;
        }
    }
}
