using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raven : MonoBehaviour
{

    public GameObject player; // Assign the player GameObject from the Unity editor.
    public Animator animator; // Assign the Animator component of the object with the animation.
    public int time =10;
    private bool hasPlayedAnimation = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player && !hasPlayedAnimation)
        {
            hasPlayedAnimation = true;
            animator.Play("ravenn"); // Replace "YourAnimationName" with the actual animation you want to play.
            
            // Wait for the animation to finish playing before destroying the object.
            AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
            float animationDuration = clips[1].length; // Assumes the animation you want to play is the first one in the Animator.
            if (time <=0) gameObject.SetActive(false);
            else time-=1;
        }
    }

    private void DestroyObject()
    {
       gameObject.SetActive(false);
    }

    }
