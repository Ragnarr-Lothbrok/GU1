using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{

    private Rigidbody2D rb;
    public GameObject scythe;
    public GameObject crossbow;
    public GameObject deathhole;
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = null;
        rb = gameObject.GetComponent<Rigidbody2D>();


    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, 10f);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Vector3 enemypos = collision.transform.position;

            Instantiate(scythe, enemypos, new Quaternion(0, 0, 0, 0));

            Destroy(collision.gameObject);
            //collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
            if(collision.tag == "Enemy")
        {
            Vector3 enemypos = collision.transform.position;

            Instantiate(crossbow, enemypos, new Quaternion(0, 0, 0, 0));

            Destroy(collision.gameObject);
            //collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
            if (collision.tag == "Enemy")
        {
            Vector3 enemypos = collision.transform.position;

            Instantiate(deathhole, enemypos, new Quaternion(0, 0, 0, 0));

            Destroy(collision.gameObject);
            //collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
