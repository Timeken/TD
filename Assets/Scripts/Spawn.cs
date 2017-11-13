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
            Instantiate(enemyList[currentEnemy], transform.position, Quaternion.identity);
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
