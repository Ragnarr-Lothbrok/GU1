using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : MonoBehaviour
{ 

private Rigidbody2D rb;
// Start is called before the first frame update

public GameObject CrossbowBolt;
void Start()
{

    rb = gameObject.GetComponent<Rigidbody2D>();
}

// Update is called once per frame
void Update()
{
        //rb.velocity = new Vector2(10, 0f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(CrossbowBolt, gameObject.transform.position, new Quaternion(0, 0, 0, 0));
        }
    }

private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.tag == "Enemy")
    {
        Vector3 enemypos = (collision.transform.position);   


        Instantiate(CrossbowBolt, enemypos, new Quaternion(0, 0, 0, 0));

        CrossbowBolt.transform.parent = null;
        collision.gameObject.SetActive(false);
        Destroy(gameObject);
    }
}      
}