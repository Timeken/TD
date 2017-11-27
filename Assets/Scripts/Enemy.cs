using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    public float FullHP, DMG, currentHP, dollarValue;

    PlayerHandler playerHandler;

    public void Start()
    {
        currentHP = FullHP;

        GameObject goal = GameObject.Find("Goal");
        GameObject spawn = GameObject.Find("Spawn");

        if (goal)
        {
           GetComponent<NavMeshAgent>().Warp(spawn.transform.position);
           GetComponent<NavMeshAgent>().SetDestination(goal.transform.position);
        }
    }


    public bool TakeDamage(float enemydamage, GameObject gameObject) 
    {
        bool enemyDead = false;

        currentHP -= enemydamage; 

        if (currentHP <= 0)
        {
            Destroy(gameObject);
            enemyDead = true;

            gameObject = GameObject.FindGameObjectWithTag("MainCamera");
            playerHandler = gameObject.GetComponent<PlayerHandler>();

            playerHandler.dollarValue += dollarValue;
        }

        return enemyDead;
    }

    public void OnTriggerEnter(Collider collider) 
    {
        if (collider.name == "Goal")
        {
            Destroy(gameObject);            
        }
    }
}
