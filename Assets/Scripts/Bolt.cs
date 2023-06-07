using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bolt : MonoBehaviour
{

    private Rigidbody2D rb;

   // public GameObject CrossbowBolt;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(10, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Vector3 enemypos = (collision.transform.position);


          //  Instantiate(CrossbowBolt, enemypos, new Quaternion(0, 0, 0, 0));

           // CrossbowBolt.transform.parent = null;
            collision.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

}
