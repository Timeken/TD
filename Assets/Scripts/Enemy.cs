using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    public int HP, DMG;

    public int SetHP
    {
        get { return HP; }
        set { HP = value; }
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
            //TODO decrease goal health here.
            Destroy(gameObject);

            tempGoal.DecreaseHealth(DMG);
            if (tempGoal.GetHealth() <= 0)
            {
                Destroy(GameObject.Find("Goal"));
            }
        }
        else if (collider.name == "projectile")
        {
            //TODO get dmg from projectile and decrese enemy hp.
        }
    }
}
