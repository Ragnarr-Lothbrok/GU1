using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro

public class GameManager : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    public GameObject theEndButtons;

    public TextMeshProUGUI scoreHolder;
    public int theScore = 0;

    public bool isleft = true;
    public float enemyMoveSpace = 2f;
    public float buffer = .2f;

    float height = 0;
    float width = 0;

    public float timeBetweenMoves = 1f;
    public float currentTime;
    public float endPoint = 0;

    public void Start()
    {
        endPoint = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position.y;

        height = Camera.main.orthographicSize * 2.0f;
        width = height * Screen.width / Screen.height;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;

        if(currentTime < 0)
        {
            {
                MovementControl();
            }

            currentTime = timeBetweenMoves;
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            ResetGame();
        }
    }

    public void MovementControl()
    {
        int movementState = 0;

        foreach (GameObject enemy in enemies)
    }
}
