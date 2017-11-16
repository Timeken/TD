using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalHPBar : MonoBehaviour {

    public Slider GoalHpSlider;
    Goal myGoal = new Goal();

    // Use this for initialization
    void Start () {
        myGoal = GetComponent<Goal>();
        GoalHpSlider.maxValue = myGoal.GoalHealth;
        GoalHpSlider.minValue = 0;
	}
	
	// Update is called once per frame
	void Update () {
        GoalHpSlider.value = myGoal.GoalCurrentHealth;
	}
}
