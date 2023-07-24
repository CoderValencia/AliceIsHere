using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch : MonoBehaviour
{


    public GameObject object1; // Assign Object1 from the Unity editor.
    public float countdownTime = 2f; // Set the time for the countdown in seconds.

    private bool isTouching = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == object1 && !isTouching)
        {
            isTouching = true;
            StartCoroutine(DisappearAfterDelay());
        }
    }

    private System.Collections.IEnumerator DisappearAfterDelay()
    {
        float timeRemaining = countdownTime;

        // Update the countdown time in the Unity editor.
        while (timeRemaining > 0f)
        {
            yield return new WaitForSeconds(1f);
            timeRemaining -= 1f;
        }

        // Countdown completed, set the object inactive.
        object1.SetActive(false);
    }

}
