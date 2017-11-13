using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public List<GameObject> enemyList;

    public float interval = 2;

    Wave wave = new Wave();

    Enemy enemy = new Enemy();

    int[] spawningEnemy;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnNext", interval, interval);
        spawningEnemy = wave.GetWave();
    }
	
	void SpawnNext () {
        for (int i = 0; i < spawningEnemy.Length; i++)
        {
            for (int j = 0; j < spawningEnemy[i]; j++)
            {
                Instantiate(enemyList[i], transform.position, Quaternion.identity);
                if (spawningEnemy.Length == 0)
                {
                    CancelInvoke("SpawnNext");
                }
            }
        }
    }
}
