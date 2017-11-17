using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
    
    public float FullHP, DMG, currentHP, dollarValue; // Maybe it's a problem that there are so many global variables, but, oh well.

    PlayerHandler playerHandler;
    Goal tempGoal = new Goal();
    
    public void Start()
    {
        currentHP = FullHP;

        GameObject goal = GameObject.Find("Goal");

        if (goal)
        {
           GetComponent<NavMeshAgent>().destination = goal.transform.position;
        }
    }

    public bool TakeDamage(float enemydamage, GameObject gameObject) // Gets called every time the minion takes damage.
    {
        bool enemyDead = false;

        currentHP -= enemydamage; // Hpbar value is connected to currentHP, so it will change accordingly.
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
        if (collider.name == "Goal") //If enemy hit the goal, then take dmg.
        {
            Destroy(gameObject);

            tempGoal.DecreaseHealth(DMG);
            if (tempGoal.GetHealth() <= 0)
            {
                Destroy(GameObject.Find("Goal")); 
                // We need to add some sorts of Game Over screen here, with a "Play again" button and a "Exit game"-button.
            }
        }

        else if (collider.name == "projectile")
        {
            //TODO destroy projectile when they hit an enemy.
        }
    }
}
