using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hpbar : MonoBehaviour
{
    public Slider HPslider;
    Enemy myEnemy;  

    public void Start()
    {
      myEnemy = GetComponent<Enemy>(); // The enemy that the bar is connected to.
        HPslider.maxValue = myEnemy.FullHP; // Sets the slider's max value to the enemy's max health.
        HPslider.minValue = 0; 
    }

    public void Update()
    {
        HPslider.value = myEnemy.currentHP; // Sets the slider's value to the current HP.
    }

}
