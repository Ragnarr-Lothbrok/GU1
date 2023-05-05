using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //Enemy Movement Variables
    public Vector2 moveToPlayer;
    public Rigidbody2D rb;
    public Vector2 localScale;
    public float enemyMoveSpeed = 2f;

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
    }
}