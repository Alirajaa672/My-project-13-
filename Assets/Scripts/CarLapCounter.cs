using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Add this line for scene management
using System;

public class CarLapCounter : MonoBehaviour
{
    private int passedCheckPointNumber = 0;
    private float lapStartTime = 0;
    private int numberOfPassedCheckpoints = 0;
    private bool isRaceStarted = false;
    private float raceStartTime = 0;

    private Rigidbody2D carRigidbody; // Assuming you have a Rigidbody2D component

    // Event
    public event Action<CarLapCounter> OnPassCheckpoint;

    private void Start()
    {
        carRigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (!isRaceStarted && collider2D.CompareTag("CheckPoint") && collider2D.GetComponent<CheckPoint>().checkPointNumber == 1)
        {
            StartRace();
        }

        if (isRaceStarted && collider2D.CompareTag("CheckPoint"))
        {
            CheckPoint checkPoint = collider2D.GetComponent<CheckPoint>();

            if (checkPoint != null)
            {
                // Check if the car is moving forward through the checkpoint
                Vector2 checkpointDirection = collider2D.transform.position - transform.position;
                float dotProduct = Vector2.Dot(checkpointDirection, carRigidbody.velocity);

                if (dotProduct > 0 && passedCheckPointNumber + 1 == checkPoint.checkPointNumber)
                {
                    passedCheckPointNumber = checkPoint.checkPointNumber;
                    numberOfPassedCheckpoints++;

                    if (passedCheckPointNumber == 1)
                    {
                        // Start timing for lap only when passing the first checkpoint
                        lapStartTime = Time.time;
                    }

                    OnPassCheckpoint?.Invoke(this);

                    Debug.Log($"Car {gameObject.name} passed checkpoint {passedCheckPointNumber} at {Time.time - lapStartTime} seconds");

                    // Check if it's the last checkpoint
                    if (passedCheckPointNumber == 10)
                    {
                        // Change the scene when the last checkpoint is touched
                        ChangeScene();
                    }
                }
            }
            else
            {
                Debug.LogError($"CheckPoint component not found on {collider2D.gameObject.name}");
            }
        }
    }

    private void ChangeScene()
    {
        // Replace "YourSceneName" with the name of the scene you want to load
        SceneManager.LoadScene(4);
    }

    private void StartRace()
    {
        isRaceStarted = true;
        raceStartTime = Time.time;
    }

    // Additional methods
    public int GetNumberOfCheckpointsPassed()
    {
        return numberOfPassedCheckpoints;
    }

    public float GetTimeAtLastCheckPoint()
    {
        return lapStartTime;
    }

    public void SetCarPosition(int position)
    {
        // Implement logic to handle the car's position in the race
        // This method will be called by the PositionHandler
    }
}
