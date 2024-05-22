using System.Collections;
using System.Collections.Generic;
using System.Linq; // Add this line to include LINQ
using UnityEngine;

public class PositionHandler : MonoBehaviour
{
    public List<CarLapCounter> carLapCounters = new List<CarLapCounter>();

    // Start is called before the first frame update
    void Start()
    {
        // Assuming you already have a reference to the CarLapCounters in the scene
        CarLapCounter[] carLapCounterArray = FindObjectsOfType<CarLapCounter>();
        carLapCounters = new List<CarLapCounter>(carLapCounterArray);

        // Hook up the passed checkpoint event for each CarLapCounter
        foreach (CarLapCounter lapCounter in carLapCounters)
        {
            lapCounter.OnPassCheckpoint += OnPassCheckpoint;
        }
    }

    void OnPassCheckpoint(CarLapCounter carLapCounter)
    {
        // Order the carLapCounters based on checkpoints passed and time
        carLapCounters = carLapCounters.OrderByDescending(s => s.GetNumberOfCheckpointsPassed()).ThenBy(s => s.GetTimeAtLastCheckPoint()).ToList();

        // Get the cars position
        int carPosition = carLapCounters.IndexOf(carLapCounter) + 1;

        // Tell the lap counter which position the car has
        carLapCounter.SetCarPosition(carPosition);
    }
}
