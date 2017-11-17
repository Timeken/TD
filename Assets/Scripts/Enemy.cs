using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
    
    public int FullHP, DMG, currentHP, dollarValue; // Maybe it's a problem that there are so many global variables, but, oh well.

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

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            TakeDamage(30);  // Check to see if the HP bar works
            print("Damage done!");     
            
            if(currentHP <= 0)
            {
                print("Enemy defeated!"); // Maybe make a method here. Maybe not.
            }
        }
    }

    public void TakeDamage(int enemydamage) // Gets called every time the minion takes damage.
    {
        currentHP -= enemydamage; // Hpbar value is connected to currentHP, so it will change accordingly.
    }


    public void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "Goal")
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
            //TODO get dmg from projectile and decrease enemy hp.
        }
    }
}
