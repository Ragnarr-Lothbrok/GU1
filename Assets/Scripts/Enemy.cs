using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //Enemy Movement Variables
    public Vector2 moveToPlayer;
    public Rigidbody2D rb;
    public Vector2 localScale;
    public float enemyMoveSpeed;

    //Other Enemy Variables
    public int enemyHealth;
    public int enemyDamage;

    //Boss Movement Extras
    public bool pauseMove = false;
    public float moveTimer = 0f;
    public float pauseTimer = 0f;

    private Transform playerTrans;

    // Start is called before the first frame update
    void Start()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        moveToPlayer = (playerTrans.position - transform.position).normalized;
        rb.velocity = new Vector2(moveToPlayer.x, moveToPlayer.y) * enemyMoveSpeed;

        if(rb.velocity.x <= 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else 
            if(rb.velocity.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    //Bosses pause movement mechanic
    private void StopBossMove()
    {

        moveTimer += Time.deltaTime;
        if (moveTimer > 5f) //timer for pause mechanic to trigger every 5 seconds
        {
            pauseMove = true;
        }

        if (pauseMove == true) //timer for the pause duration of 1 second starts
        {
            pauseTimer += Time.deltaTime;
            enemyMoveSpeed = 0;

}

        if (pauseTimer > 1f) //if the pause is longer than one second the boss will start moving again
        {
            moveTimer = 0f;
            enemyMoveSpeed = 5f;
            pauseTimer= 0f;
        }
    }
}
