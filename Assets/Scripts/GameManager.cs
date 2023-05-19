using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();

    public float buffer = .2f;

    float height = 0;
    float width = 0;

    public float timeBetweenMoves = 1f;
    public float currentTime;
    public float endPoint = 0;

//Enemy Movement Variables
    public Vector2 moveToPlayer;
    public Vector2 localScale;
    public float enemyMoveSpeed = 2f;

    public void Start()
    {
        endPoint = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position.y;

        height = Camera.main.orthographicSize * 2.0f;
        width = height * Screen.width / Screen.height;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("");
    }
}
