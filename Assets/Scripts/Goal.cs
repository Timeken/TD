using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    [SerializeField]
    public float GoalHealth = 100;
    public float GoalCurrentHealth;

    public void DecreaseHealth(float DMG)
    {
        GoalHealth -= DMG;
    }

    public float GetHealth()
    {
        return GoalHealth;
    }

	// Use this for initialization
	void Start () {
        GoalCurrentHealth = GoalHealth;
	}

}
