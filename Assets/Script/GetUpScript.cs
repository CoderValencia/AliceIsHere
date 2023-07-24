using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetUpScript : MonoBehaviour
{
    public int timer = 100;
    void Awake()
    {
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<Animator>().SetBool("IsGettingUp", true);
    }

    void FixedUpdate()
    {
        timer--;
        
        if (timer == 0)
        {
            GetComponent<PlayerMovement>().enabled = true;
            GetComponent<Animator>().SetBool("IsGettingUp", false);
            Destroy(this);
            
        }
    }
}
