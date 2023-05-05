using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Button startButton;
    public Button rulesButton;
    public Button quitButton;

    void Start()
    {
        // Add event listeners to the buttons
        startButton.onClick.AddListener(StartGame);
        rulesButton.onClick.AddListener(LoadRules);
        quitButton.onClick.AddListener(QuitGame);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void LoadRules()
    {
        SceneManager.LoadScene("How-to");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
