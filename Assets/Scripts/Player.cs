using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.VersionControl;//
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{

    public float speed;
    public int maxhealth = 5;
    public int currentHealth;
    private Rigidbody2D rb;

    public GameObject weapon;

    public Vector2 weaponAreaL, WeaponAreaR;

    //Damage Cooldown
    private float damageCoolDown = 1f;
    private bool invulnerable = false;

    private Vector2 moveInput;

    public GameObject crossbowPF;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 800f;



        currentHealth = maxhealth;
    }


    void Update()
    {
        //so clean, so smooth.
        float moveInputX = Input.GetAxisRaw("Horizontal");
        float moveInputY = Input.GetAxisRaw("Vertical");

        moveInput = new Vector2(moveInputX, moveInputY).normalized;
        //  Debug.Log("input test ="+moveInput);
        rb.velocity = moveInput * speed * Time.deltaTime;



        //Checking for Player Death
        if (currentHealth <= 0)
        {
            GameOver();
        }

        //MARKS UPDATED TURNING CODE.
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (rb.velocity.x <= 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);

                // WE NEED TO GET TRANSFORM.ROTATION.Y TO 0 HERE

            }
        }
        else
            if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (rb.velocity.x > 0)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
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
            Debug.Log("COLLISION HAPPENING WITH " + collision.gameObject.name);
            currentHealth--;
        }

    }
    void TakeDamage(int damage)
    {
        currentHealth = currentHealth - damage;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("LoseScene");
    }

    //private void FlipCharacterRight()
    //{
    //    if(rb.velocity <= 0)
    //    {
    //        Deb
    //    }
    //}
}