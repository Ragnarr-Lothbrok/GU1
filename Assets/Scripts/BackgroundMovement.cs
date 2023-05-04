using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMovement : MonoBehaviour
{
    float screenHeight;
    float screenWidth;

    public float scrollSpeed = 0.003f;

    private bool isMoving = true;
    private float movementCompleteTime = 0f;
    private float movementCompleteDelay = 2f;

    void Start()
    {
        // Get the height and width of the screen in world units
        screenHeight = Camera.main.orthographicSize * 2f;
        screenWidth = screenHeight * Camera.main.aspect;
    }

    void Update()
    {
        if (isMoving)
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

                // Set the flag to indicate that movement is complete and record the time
                isMoving = false;
                movementCompleteTime = Time.time;

                // Trigger the delay before loading the next scene
                StartCoroutine(DelayedSceneLoad());
            }

            // Set the position of the Background GameObject to the new position
            transform.position = currentPosition;
        }
    }

    IEnumerator DelayedSceneLoad()
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(movementCompleteDelay);

        // Load the next scene
        SceneManager.LoadScene("BossRoom");
    }
}
