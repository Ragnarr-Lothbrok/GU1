using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameManager manager;
    public Camera checkCam;
    public GameObject Enemy;

    public float maxPos = 2.4f;
    public float delayTimer = 2f;
    public float timeNeed = 10f;
    public float time = 0f;
    float timer;
    public float height;
    public float width;

    // Start is called before the first frame update
    void Start()
    {
        checkCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        manager = gameObject.GetComponent<GameManager>();
        //manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        manager.enemies.Add(gameObject);

        height = checkCam.orthographicSize + 1;
        width = checkCam.orthographicSize * checkCam.aspect + 1;


        timer = delayTimer;
    }

    // Update is called once per frame
    void Update()
    {
        //spawn more enemies on a timer
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            //  Vector3 enemyPos = new Vector3(width, height, transform.position.z);
            //  Instantiate(Enemy, enemyPos, transform.rotation);
            SetSpawnLocation();
            timer = delayTimer;
        }




        //spawns enemies just outside camera border  
        // float height = cam.orthographicSize + 1; 
        // float width = cam.orthographicSize * cam.aspect + 1;
    }

    void SetSpawnLocation()
    {
        bool isLeft;
        bool isBottom;

        float enemyPosY, enemyPosX;


        int randomiser = 0;

        randomiser = Random.Range(0, 2);


        // HORIZONTAL SPAWN CONTROLS
        if (randomiser == 0)
        {
            randomiser = Random.Range(-8, 8);

            isLeft = true;
            enemyPosX = 0 - checkCam.orthographicSize - checkCam.aspect + randomiser;
        }
        else
        {
            isLeft = false;
            enemyPosX = width;
        }

        randomiser = Random.Range(0, 2);



        if (randomiser == 0)
        {
            randomiser = Random.Range(-9, 9);

            isBottom = true;
            enemyPosY = 0 - checkCam.orthographicSize + randomiser;
        }
        else
        {
            isBottom = false;
            enemyPosY = height;
        }

        Vector3 enemyPos = new Vector3(enemyPosX, enemyPosY, transform.position.z);


        Instantiate(Enemy, enemyPos, transform.rotation);
        Debug.Log("Player X is moving to " + isLeft + "\n The player Y is " + isBottom);
    }
}