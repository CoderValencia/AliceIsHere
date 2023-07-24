using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch : MonoBehaviour
{


    public float flashDuration = 5f; // The duration of the object flash in seconds.
    public float disappearDelay = 5f; // The delay before the object disappears after the flash.

    public GameObject interactingObject; // Assign the interacting object in the Unity editor.

    private SpriteRenderer objectRenderer;
    private bool isTouching = false;

    private void Start()
    {
        objectRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == interactingObject && !isTouching)
        {
            // The player (Object1) touched this object.
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
        // Flash the object by turning it on and off for a short duration.
        float startTime = Time.time;
        while (Time.time - startTime < flashDuration)
        {
            objectRenderer.enabled = !objectRenderer.enabled;
            yield return new WaitForSeconds(0.1f);
        }

        // Ensure the object is visible again before disappearing.
        objectRenderer.enabled = true;

        // Wait for the specified delay before making the object disappear.
        yield return new WaitForSeconds(disappearDelay);

        // Hide this object.
        gameObject.SetActive(false);

        // Reset the flag so the object can interact with other objects.
        isTouching = false;
    }


}
