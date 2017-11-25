using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalHPBar : MonoBehaviour
{
    public Slider GoalHpSlider;
    public Text GoalHealthText; 
    Goal myGoal;

    void Start()
    {
        myGoal = GetComponent<Goal>();
        GoalHpSlider.maxValue = myGoal.GoalHealth; 
        GoalHpSlider.minValue = 0;
    }

    void Update()
    {
        GoalHpSlider.value = myGoal.GoalCurrentHealth; 
        GoalHealthText.text = GoalHpSlider.value.ToString() + "HP"; 
    } 

}
