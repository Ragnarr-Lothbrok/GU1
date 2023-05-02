using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    
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
        SceneManager.LoadScene("");
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

    private void MoveHorizontal(GameObject theEnemy)
    {
        if(isleft)
        {
            float newPos = theEnemy.transform.position.x - enemyMoveSpace;

            theEnemy.transform.position = new Vector3(newPos, theEnemy.transform.position.y);
        }
        else
        {
            float newPos = theEnemy.transform.position.y - enemyMoveSpace;

            theEnemy.transform.position = new Vector3(newPos, theEnemy.transform.position.y);
        }
    }

    private void MoveVertical(GameObject theEnemy)
    {
        float newPos = theEnemy.transform.position.y - enemyMoveSpace;

        theEnemy.transform.position = new Vector3(newPos, theEnemy.transform.position.x, newPos);
    }

    public void MovementControl()
    {
        int movementState = 0;

        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)
            {
                MoveHorizontal(enemy);
            }

            if (enemy.transform.position.x <= 0 - width / 2 + buffer)
            {
                movementState = 1;
            }
            else
            if (enemy.transform.position.x >= 0 + width / 2 - buffer)
            {
                movementState = 2;
            }
        }

        if(movementState == 1)
        {
            isleft = false;
            movementState = 0;
            foreach(GameObject enemy in enemies)
            {
                if(enemy != null)
                {
                    MoveVertical(enemy);
                }
            }
        }
        else
            if(movementState == 2)
        {
            isleft = true;
            movementState = 0;
            foreach(GameObject enemy in enemies)
            {
                if(enemy != null)
                {
                    MoveVertical(enemy);
                }
            }
        }
    }
}
