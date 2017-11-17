using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    [SerializeField]
    public int GoalHealth = 100;
    public int GoalCurrentHealth;

    public void DecreaseHealth(int DMG)
    {
        GoalHealth -= DMG;
    }

    public int GetHealth()
    {
        return GoalHealth;
    }

	// Use this for initialization
	void Start () {
        GoalCurrentHealth = GoalHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
