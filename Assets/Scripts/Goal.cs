using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public float GoalHealth = 77f, GoalCurrentHealth;
    [SerializeField]
    GameObject gameOverScreen;

    // Use this for initialization
    void Start()
    {
        GoalCurrentHealth = GoalHealth;
        gameOverScreen.gameObject.SetActive(false);
    }

    private void Update()
    {
         if (GoalCurrentHealth <= 0f)
        {
            print("GAME OVER!");
            Destroy(GameObject.Find("Goal"));
            gameOverScreen.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public float GetHealth()
    {
        return GoalCurrentHealth;
    }

    public void OnTriggerEnter(Collider collidingEnemy)
        {
            if (collidingEnemy.GetComponent<Minion1>())
            {
                GoalCurrentHealth -= collidingEnemy.GetComponent<Minion1>().EnemyGetDMG();
                print("An UFO has collided with the goal.");
            }
        }
    }
