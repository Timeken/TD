using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float FullHP, DMG, currentHP;
    public int dollarValue;
    
    public void Start()
    {
        currentHP = FullHP;

        GameObject goal = GameObject.Find("Goal");

        if (goal)
        {
           GetComponent<NavMeshAgent>().destination = goal.transform.position;
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

        if (currentHP < 0)
        {
            Destroy(gameObject);
            enemyDead = true;
        }

        return enemyDead;
    }

     public void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Goal")
        {
            Destroy(gameObject);
            
        }

        else if (collider.name == "projectile")
        {
            //TODO get dmg from projectile and decrease enemy hp.
        }
    }
}
