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
    private Transform playerTrans;

    public bool isBoss = false;

    //Other Enemy Variables
    public int enemyHealth;
    public float enemyDamage;

    //Boss Movement Extras
    public bool pauseMove = false;
    public float moveTimer = 5f;
    public float testTimer = 10f;
    public float moveDuration;
    public float pauseDuration;

    // Start is called before the first frame update
    void Start()
    {
        playerTrans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //Bosses pause movement mechanic

        moveTimer -= Time.deltaTime;

        if (moveTimer <= 0f && pauseMove == false)
        {
            pauseMove = true;
        }

        if (pauseMove == false)
        {
            MoveEnemy();
        }

        if (pauseMove == true)
        {
            pauseDuration -= Time.deltaTime;

            if (pauseDuration <= 0f)
            {
                moveTimer = 5f;
                pauseDuration = 3f;
                testTimer = 10f;
                pauseMove = false;
            }
        }

    }

    private void MoveEnemy()
    {
        testTimer -= Time.deltaTime;

        moveToPlayer = (playerTrans.position - transform.position).normalized;

        if (isBoss == true)
        {

            if (testTimer <= 6)
            {
                rb.velocity = new Vector2(moveToPlayer.x, moveToPlayer.y) * 0;
            }
            else
            {
                rb.velocity = new Vector2(moveToPlayer.x, moveToPlayer.y) * enemyMoveSpeed;
            }
        }
        else
        {
            rb.velocity = new Vector2(moveToPlayer.x, moveToPlayer.y) * enemyMoveSpeed;
        }

        if (rb.velocity.x <= 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
            if (rb.velocity.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}