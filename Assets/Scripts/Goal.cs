using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    [SerializeField]
    public float GoalHealth = 150f;
    public float GoalCurrentHealth;

	// Use this for initialization
	void Start () {
        GoalCurrentHealth = GoalHealth;
	}

    public float GetHealth()
    {
        return GoalCurrentHealth;
    }

    public void OnTriggerEnter(Collider collidingEnemy) 
    {
        if (GoalCurrentHealth >= 0f)
        {

            if (collidingEnemy.GetComponent<Minion1>())
            {
                GoalCurrentHealth -= collidingEnemy.GetComponent<Minion1>().EnemyGetDMG();
                print("An UFO has collided with the goal.");
            }
            else if (collidingEnemy.GetComponent<Minion2>())
            {
                GoalCurrentHealth -= collidingEnemy.GetComponent<Minion2>().EnemyGetDMG();
                print("A Cube has collided with the goal.");
            }
        }

        else if (GoalCurrentHealth <= 0f)
        { 
                print("GAME OVER!");
                Destroy(GameObject.Find("Goal"));
                // We need to add some sorts of Game Over screen here, with a "Play again" button and a "Exit game"-button.
            }
        }
}
