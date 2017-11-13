using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    [SerializeField]
    int GoalHealth = 10;

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
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
