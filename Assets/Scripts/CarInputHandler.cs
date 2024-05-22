using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInputHandler : MonoBehaviour
{
    public bool isUIInput = false;
    Vector2 inputVector = Vector2.zero;

    TopDownCarController topDownCarController;

    void Awake()
    {
        topDownCarController = GetComponent<TopDownCarController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isUIInput)
        {
            inputVector.x = Input.GetAxis("Horizontal");
            inputVector.y = Input.GetAxis("Vertical");
            topDownCarController.SetInputVector(inputVector);
        }
    }

    // Add this method to set the input vector
    public void SetInput(Vector2 newInput)
    {
        inputVector = newInput;
        topDownCarController.SetInputVector(inputVector);
    }
}