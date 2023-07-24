using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchAndDisappear : MonoBehaviour
{
    public float flashDuration = 0.2f; // The duration 
    public float disappearDelay = 1f; // The delay 

    public GameObject player; // Assign the player G.

    private Renderer objectRenderer;
    private bool isTouching = false;

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
    }

    private void OnMouseDown()
    {
       
        if (!isTouching && player != null)
        {
           
            StartFlashAndDisappear();
        }
    }

    private void StartFlashAndDisappear()
    {
        if (!isTouching)
        {
            isTouching = true;
            StartCoroutine(FlashAndDisappear());
        }
    }

    private IEnumerator FlashAndDisappear()
    {
       
        float startTime = Time.time;
        while (Time.time - startTime < flashDuration)
        {
            objectRenderer.enabled = !objectRenderer.enabled;
            yield return new WaitForSeconds(0.1f);
        }

       
        objectRenderer.enabled = true;

      
        yield return new WaitForSeconds(disappearDelay);

       
        gameObject.SetActive(false);


        isTouching = false;
    }
}

