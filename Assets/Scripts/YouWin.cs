using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class YouWin : MonoBehaviour
{
    public GameObject YouWinpanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            // Check if the collider belongs to the car, and if it does, show the YouWinpanel
            ShowYouWinPanel();
        }
    }

    private void ShowYouWinPanel()
    {
        if (YouWinpanel != null)
        {
            YouWinpanel.SetActive(true);
        }
        else
        {
            Debug.LogError("YouWinpanel reference is not set in the inspector.");
        }
    }
}
