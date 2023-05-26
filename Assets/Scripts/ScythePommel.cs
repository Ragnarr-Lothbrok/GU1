using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScythePommel : MonoBehaviour
{
    public int weaponType = 0;

    public float speed = 5;
    public float backspeed = -5;


    public float maxTimer;
    public float minTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (weaponType == 3)
        {
            if (minTimer <= 0)
            {
                transform.Rotate(new Vector3(0, 0, 200) * Time.deltaTime);

            }
        }
    }
}
