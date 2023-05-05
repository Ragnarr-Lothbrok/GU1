using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI tmpGUI; // Reference to the TextMeshProUGUI component that displays the time
    private float startTime; // The time when the timer starts
    private bool timerIsRunning = false; // Flag to indicate if the timer is currently running
    private float originalTimeLimit = 30f; // The original time limit for the timer in seconds
    private float timeLimit; // The current time limit for the timer in seconds

    void Start()
    {
        // Initialize the time limit and start time
        timeLimit = originalTimeLimit;
        startTime = Time.time;

        // Set the timer flag to true
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            // Calculate the elapsed time since the timer started
            float t = Time.time - startTime;

            // Convert the elapsed time to minutes and seconds format
            string minutes = Mathf.FloorToInt(t / 60f).ToString("00");
            string seconds = Mathf.FloorToInt(t % 60f).ToString("00");

            // Update the TextMeshProUGUI component with the current time
            tmpGUI.text = "Time: " + minutes + ":" + seconds;

            // Check if the time limit has been reached
            if (t >= timeLimit)
            {
                // If the time limit has been reached, load the ChurchSplash scene
                SceneManager.LoadScene("ChurchSplash");

                // Stop the timer by setting the flag to false
                timerIsRunning = false;
            }
        }
    }

    public void Reset()
    {
        // Re-initialize the start time and timer flag
        startTime = Time.time;
        timerIsRunning = true;
    }

    public void SetTimeLimit(float newTimeLimit)
    {
        // Update the time limit and reset the timer
        timeLimit = newTimeLimit;
        Reset();
    }
}
