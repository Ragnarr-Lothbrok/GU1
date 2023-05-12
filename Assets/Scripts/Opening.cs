using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Opening : MonoBehaviour
{
    public float timeBeforeSceneSwitch, currentTime;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = timeBeforeSceneSwitch;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;

        if(currentTime <= 0)
        {
            SceneManager.LoadScene("Level");
        }
    }
}
