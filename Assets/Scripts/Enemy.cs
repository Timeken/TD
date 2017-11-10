using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject goal = GameObject.Find("Goal");
        if (goal)
        {
            GetComponent<NavMeshAgent>().destination = goal.transform.position;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Goal")
        {
            //decreas goal health here.
            Destroy(gameObject);
        }
    }
}
