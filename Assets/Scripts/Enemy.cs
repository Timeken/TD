using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    public int FullHP, DMG;

    public int SetHP
    {
        get { return FullHP; }
        set { FullHP = value; }
    }

    Goal tempGoal = new Goal();
    
    // Use this for initialization
    public void Start()
    {       
        GameObject goal = GameObject.Find("Goal");
        if (goal)
        {
            GetComponent<NavMeshAgent>().destination = goal.transform.position;
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Goal")
        {
            Destroy(gameObject);

            tempGoal.DecreaseHealth(DMG);
            if (tempGoal.GetHealth() <= 0)
            {
                Destroy(GameObject.Find("Goal")); // When goal's HP is zero, delete it.
                // We need to add some sorts of Game Over screen here, with a "Play again" button and a "Exit game"-button.
            }
        }
        else if (collider.name == "projectile")
        {
            //TODO get dmg from projectile and decrese enemy hp.
        }
    }
}
