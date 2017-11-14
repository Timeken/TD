using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    [SerializeField]
    public int HP, DMG;

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
            tempGoal.DecreaseHealth(1);
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
