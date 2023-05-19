using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionTutorial : MonoBehaviour
{
    public void GoToNextScene()
    {
        SceneManager.LoadScene("Main Menu");
    }
}

