using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    float screenHeight;
    float screenWidth;

    public float scrollSpeed = 0.005f;

    void Start()
    {
        // Get the height and width of the screen in world units
        screenHeight = Camera.main.orthographicSize * 2f;
        screenWidth = screenHeight * Camera.main.aspect;
    }

    void Update()
    {
        // Get the current position of the Background GameObject
        Vector3 currentPosition = transform.position;

        // Move the background down by the scroll speed
        currentPosition.y -= scrollSpeed;

        // Check if the current position is at or below the bottom of the screen
        if (currentPosition.y <= -screenHeight / 2f)
        {
            // If the current position is at or below the bottom of the screen, stop moving the background
            currentPosition.y = -screenHeight / 2f;
        }

        // Set the position of the Background GameObject to the new position
        transform.position = currentPosition;
    }
}

