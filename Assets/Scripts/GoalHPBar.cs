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
        GoalHpSlider.maxValue = myGoal.GoalHealth; // Sets the max and min values of the goal's health bar.
        GoalHpSlider.minValue = 0;
    }

    void Update()
    {
        GoalHpSlider.value = myGoal.GoalCurrentHealth; // Updates the value on the goal's health bar.
        GoalHealthText.text = GoalHpSlider.value.ToString(); // Sets the text on the bar to the same value.
    } 

}
