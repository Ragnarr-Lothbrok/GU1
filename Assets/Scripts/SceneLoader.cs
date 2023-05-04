using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public float delay = 1f; // The delay before the scene is loaded in seconds
    private bool isMoving = false; // Flag to indicate if the background is currently moving

    void Update()
    {
        if (isMoving)
        {
            // Check if the background has finished moving
            if (transform.position.y <= -Camera.main.orthographicSize)
            {
                // If the background has finished moving, load the ChurchSplash scene after the delay
                Invoke("LoadScene", delay);

                // Set the isMoving flag to false to prevent the scene from being loaded multiple times
                isMoving = false;
            }
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene("ChurchSplash");
    }

    public void SetIsMoving(bool value)
    {
        // Set the isMoving flag to the specified value
        isMoving = value;
    }
}

