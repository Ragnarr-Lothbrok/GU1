using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb;

    private Vector2 moveInput;

    void Start()
    {
        speed = 5f;
    }

    void Update()
    {
        moveInput.x = moveInput.GetAxisRaw("Horizontal");
        moveInput.y = moveInput.GetAxisRaw("Vertical");

        moveInput.Normalized();

        rb.velocity = moveInput * speed;
    }   
}
