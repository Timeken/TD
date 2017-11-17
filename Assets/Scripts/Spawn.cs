using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public List<GameObject> enemyList;

    public float interval = 2;

    Wave wave = new Wave();

    Enemy enemy = new Enemy();

    int[] spawningEnemy;
    int currentEnemy = 0;
    int currentWave = 1;

    // Use this for initialization
    void Start () {
        InvokeRepeating("SpawnNext", interval, interval);
        spawningEnemy = wave.GetWave(currentWave);
    }
	
	void SpawnNext () {
        if (spawningEnemy[currentEnemy] != 0)
        {
            //Spawns enemies. SetValues are temporary, change at will.
            Instantiate(enemyList[currentEnemy], transform.position, Quaternion.identity);
            if (enemyList[currentEnemy].GetComponent<Minion1>() == null)
            {
                enemyList[currentEnemy].GetComponent<Minion2>().SetValues(200, 10, 50); // HP, damage, value
            } else
            {
                enemyList[currentEnemy].GetComponent<Minion1>().SetValues(100, 5, 25); // HP, damage, value
            }
        }
        if (--spawningEnemy[currentEnemy] <= 0)
        {
            currentEnemy++;

            if (spawningEnemy.Length == currentEnemy)
            {
                //CancelInvoke("SpawnNext");
                currentWave++;
                spawningEnemy = wave.GetWave(currentWave);
                currentEnemy = 0;
            }
        }
        
    }
}
