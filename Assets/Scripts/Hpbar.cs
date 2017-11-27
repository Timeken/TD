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
      myEnemy = GetComponent<Enemy>(); 
        HPslider.maxValue = myEnemy.FullHP; 
        HPslider.minValue = 0; 
    }

    public void Update()
    {
        HPslider.transform.rotation = Quaternion.identity;
        HPslider.value = myEnemy.currentHP; 
    }

}
