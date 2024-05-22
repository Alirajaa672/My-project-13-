using UnityEngine;
using TMPro;

public class LapCounter : MonoBehaviour
{
    public TMP_Text lapCountText; // Reference to your TextMeshPro Text
    public CarLapCounter carLapCounter; // Reference to the CarLapCounter script

    private void Start()
    {
        // Make sure you have assigned the TextMeshPro Text and CarLapCounter in the Inspector
        if (lapCountText == null || carLapCounter == null)
        {
            Debug.LogError("TextMeshPro Text or CarLapCounter not assigned in the Inspector.");
            return;
        }

        // Subscribe to the CarLapCounter event
        carLapCounter.OnPassCheckpoint += UpdateLapCount;
    }

    private void UpdateLapCount(CarLapCounter carLapCounter)
    {
        int lapCount = carLapCounter.GetNumberOfCheckpointsPassed();
        lapCountText.text = "Lap: " + lapCount.ToString();
    }
}
