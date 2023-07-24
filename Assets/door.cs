using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.InteropServices;


public class DoorInteraction : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject objectToBecomeVisible;
        [SerializeField] private GameObject object2;

    // Replace "PluginName" with the actual name of your C++ plugin DLL.
  

    // Import the C++ function from the DLL.

    //private static extern void SetObjectVisibility(bool isVisible);

    private void Update()
    {
        // Calculate the distance between the player and the door.
        float distance = Vector3.Distance(player.transform.position, transform.position);

        // Check if the player is close enough to the door (adjust the threshold as needed).
        if (distance < 3.0f)
        {
            // Check for the "E" key press.
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Toggle the visibility of the object.
           
                objectToBecomeVisible.SetActive(true);
                object2.SetActive(true);

                // Inform the C++ plugin about the visibility status.
                //SetObjectVisibility(isVisible);
            }
        }
    }
}


