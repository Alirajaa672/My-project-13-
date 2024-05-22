using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText; // Reference to your TextMeshPro Text
    public float timeLimit = 60f; // Time limit for the race in seconds
    private float currentTime = 0f;
    private bool raceStarted = false;

    private void Start()
    {
        if (timerText == null)
        {
            Debug.LogError("TextMeshPro Text not assigned in the Inspector.");
            return;
        }

        ResetTimer();
    }

    private void Update()
    {
        if (raceStarted)
        {
            currentTime += Time.deltaTime;

            // Update the timer text
            timerText.text = "Time: " + currentTime.ToString("0");

            // Check win/lose condition
            if (currentTime >= timeLimit)
            {
                // Time's up, player loses
                Debug.Log("Time's up! Player loses.");
                raceStarted = false;
            }
        }
    }

    public void StartRace()
    {
        raceStarted = true;
    }

    public void ResetTimer()
    {
        currentTime = 0f;
        timerText.text = "Time: 0";
    }
}

