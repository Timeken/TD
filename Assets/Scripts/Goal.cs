﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // GoalHealth är målets maximala HP!
    public float GoalHealth = 100f, GoalCurrentHealth;  //GoalHealth ska alltid ha ett f efter siffrorna!




    [SerializeField]
    GameObject gameOverScreen;

    void Start()
    {
        GoalCurrentHealth = GoalHealth;
        gameOverScreen.gameObject.SetActive(false);
    }

    private void Update()
    {
         if (GoalCurrentHealth <= 0f)
        {
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
            }
            if (collidingEnemy.GetComponent<Minion2>())
            {
            GoalCurrentHealth -= collidingEnemy.GetComponent<Minion2>().EnemyGetDMG();
            }
    }
}
