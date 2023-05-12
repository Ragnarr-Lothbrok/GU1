using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider; //Allows the use of the bar slider.

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    //Sets the health bar to max at each start
    public void SetHealth(int health)
    {
        slider.value = health;
    }
        
   
    
}
