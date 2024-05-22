using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surface : MonoBehaviour
{
    // OnTriggerEnter2D is called when another collider enters the trigger collider attached to this GameObject
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the entering collider has the tag "OuterSurface"
        if (other.CompareTag("OuterSurface"))
        {
            // Car entered the outer surface, you can add logic here if needed
            Debug.Log("Car entered OuterSurface");
        }
        else if (other.CompareTag("InnerSurface"))
        {
            // Car entered the inner surface, you can add logic here if needed
            Debug.Log("Car entered InnerSurface");
        }
    }

    // OnTriggerExit2D is called when another collider exits the trigger collider attached to this GameObject
    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the exiting collider has the tag "OuterSurface"
        if (other.CompareTag("OuterSurface"))
        {
            // Car left the outer surface, you can add logic here if needed
            Debug.Log("Car left OuterSurface");
        }
        else if (other.CompareTag("InnerSurface"))
        {
            // Car left the inner surface, you can add logic here if needed
            Debug.Log("Car left InnerSurface");
        }
    }
}
