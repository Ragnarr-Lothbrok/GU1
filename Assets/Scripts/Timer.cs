using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    //  public Text timerText;
    public TextMeshProUGUI tmpGUI;
    private float startTime;
    private bool timerIsRunning = false;
    public float timeLimit = 900f; // 15 minutes in seconds

    void Start()
    {
        startTime = Time.time;
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            float t = Time.time - startTime;

            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f2");

            tmpGUI.text = "Time: " + minutes + ":" + seconds;

          //  timerText.text = minutes + ":" + seconds;

            if (t >= timeLimit)
            {
                SceneManager.LoadScene("BossSplash");
            }
        }
    }
}
