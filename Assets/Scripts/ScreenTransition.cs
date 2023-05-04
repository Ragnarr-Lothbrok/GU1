using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public Image transitionImage; // Reference to the Image component that will be used to transition between scenes
    public float transitionTime = 1f; // The duration of the transition animation in seconds

    // Start is called before the first frame update
    private void Start()
    {
        if (transitionImage != null) // Check that a transition Image has been assigned to the component
        {
            // Set the initial alpha of the Image to fully opaque (1.0f) and begin the fade out animation
            transitionImage.canvasRenderer.SetAlpha(1.0f);
            FadeOut();
        }
    }

    // This method begins the fade in animation
    public void FadeIn()
    {
        if (transitionImage != null) // Check that a transition Image has been assigned to the component
        {
            // Begin the fade in animation by setting the alpha of the Image to fully transparent (0.0f)
            // The CrossFadeAlpha method automatically animates the alpha value over the specified duration
            transitionImage.CrossFadeAlpha(0.0f, transitionTime, false);
        }
    }

    // This method begins the fade out animation and loads the next scene when the animation is complete
    public void FadeOut()
    {
        if (transitionImage != null) // Check that a transition Image has been assigned to the component
        {
            // Begin the fade out animation by setting the alpha of the Image to fully opaque (1.0f)
            // The CrossFadeAlpha method automatically animates the alpha value over the specified duration
            transitionImage.CrossFadeAlpha(1.0f, transitionTime, false);

            // Use the Invoke method to delay the LoadNextScene method call until the fade out animation is complete
            Invoke("LoadNextScene", transitionTime);
        }
    }

    // This method loads the next scene in the build settings
    private void LoadNextScene()
    {
        // Get the index of the current scene and calculate the index of the next scene
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;

        // If the next scene index is greater than or equal to the number of scenes in the build settings, loop back to the first scene
        if (nextIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextIndex = 0;
        }

        // Load the next scene using the SceneManager.LoadScene method and passing in the next scene index
        SceneManager.LoadScene(nextIndex);
    }
}
