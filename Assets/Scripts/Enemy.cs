using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
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
    public float moveTimer = 5f;
    public float moveDuration;
    public float pauseDuration;

    private Transform playerTrans;

    // Start is called before the first frame update
    void Start()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        moveTimer -= Time.deltaTime;
        if(moveTimer <= 0)
        {
            //Enemy Stops
            pauseMove = true;
            pauseDuration = 3f;

            pauseDuration -= Time.deltaTime;
            if (pauseDuration <= 0)
            {
                moveTimer = 5f;
            }
        }

        if (pauseMove == false)
        {
            MoveEnemy();
        }
        
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


        if(pauseDuration <= 0)
        {
            pauseDuration = 1f;
            pauseMove = false;
        }
    }

    //Bosses pause movement mechanic
    private void StopBossMove()
    {

        moveTimer -= Time.deltaTime;
        if (moveTimer <= 0)
        {
            if (pauseMove)
            {
                moveTimer = moveDuration;
                pauseMove = false;
            }
            else
            {
                moveTimer = pauseDuration;
                pauseMove = true;
            }

            return;
        }

        if (!pauseMove)
        {
            
        }
    }
}
