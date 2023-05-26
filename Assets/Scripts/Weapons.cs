using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapons : MonoBehaviour
{
    private Player Player;
    // 1 = sword, 2 = crossbow, 3 = scythe.



    private Rigidbody2D rb;

    //This is the control that is to be set on each weapon in the Inspector
    //KEY
    // 1 = sword, 2 = crossbow, 3 = scythe.
    public int weaponType = 0;
    public GameObject swordPommel;
    public GameObject scythePommel;
    public GameObject crossbowHilt;
    public int index = 0;
    public float speed = 5;
    public float backspeed = -5;
    

    public float maxTimer;
    public float minTimer;


    // Start is called before the first frame update
    void Start()
    {
        minTimer = maxTimer;

        Player = GetComponent<Player>();

        
    }


    private void Update()
    {
        minTimer -= Time.deltaTime;

        if(weaponType == 1)
        {
            if(minTimer <= 0)
            {
                Animation anim = swordPommel.GetComponent<Animation>();
                anim.Play();
                minTimer = maxTimer;
            }
        }
        
      //if (weaponType == 3)
      //{
          //if (minTimer <= 0)
          //{
              //transform.Rotate(new Vector3 (0,0,20)*Time.deltaTime);
                
          //}
      //}
        
        if (weaponType == 2)
        {
            if (minTimer <= 0)
            {
                Animation anim = scythePommel.GetComponent<Animation>();
                anim.Play();
                minTimer = maxTimer;
            }
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        { 
            Destroy(collision.gameObject);
            Debug.Log("WEAPONHIT");
        }
    }
}
