using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

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

  /*  public int EnemyGetDMG()
    {
        return DMG;
    }*/


    public bool TakeDamage(float enemydamage, GameObject gameObject) // Gets called every time the minion takes damage.
    {
        bool enemyDead = false;

        currentHP -= enemydamage; // Hpbar value is connected to currentHP, so it will change accordingly.
        //check if enemy is dead
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

    public void OnTriggerEnter(Collider collider) //If enemy hit goal destroy enemy.
    {
        if (collider.name == "Goal")
        {
            Destroy(gameObject);
            
        }
    }
}
