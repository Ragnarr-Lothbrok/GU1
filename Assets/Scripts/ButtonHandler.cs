using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadRules()
    {
        SceneManager.LoadScene("How-to");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
