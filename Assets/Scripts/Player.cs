using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb;

    private Vector2 moveInput;

    public GameObject crossbowPF;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 500f;
    }


    void Update()
    {
        //so clean, so smooth.
        float moveInputX = Input.GetAxisRaw("Horizontal");
        float moveInputY = Input.GetAxisRaw("Vertical");

        moveInput = new Vector2 (moveInputX, moveInputY).normalized;
        Debug.Log("input test ="+moveInput);
        rb.velocity = moveInput * speed * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(crossbowPF, gameObject.transform);
        }
    }   
}
