using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{

    public float speed;
    public int maxhealth = 5;
    public int currentHealth;
    private Rigidbody2D rb;

    //Damage Cooldown
    private float damageCoolDown = 1f;
    private bool invulnerable = false;

    private Vector2 moveInput;

    public GameObject crossbowPF;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 500f;

        currentHealth = maxhealth;
    }


    void Update()
    {
        //so clean, so smooth.
        float moveInputX = Input.GetAxisRaw("Horizontal");
        float moveInputY = Input.GetAxisRaw("Vertical");

        moveInput = new Vector2 (moveInputX, moveInputY).normalized;
      //  Debug.Log("input test ="+moveInput);
        rb.velocity = moveInput * speed * Time.deltaTime;

        if (rb.velocity.x <= 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
           if (rb.velocity.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(crossbowPF, gameObject.transform);
        }
    }

    void OnDamage()
    {
        if (invulnerable) return;
        invulnerable = true;
        StartCoroutine(DamageCoolDown());
    }

    private IEnumerator DamageCoolDown()
    {
        yield return new WaitForSeconds(damageCoolDown);
        invulnerable = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            currentHealth--;
        }

    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }
}
