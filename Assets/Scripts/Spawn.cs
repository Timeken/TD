using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject spwanEnemy;

    public float interval = 2;

    Wave wave = new Wave();

    int[] spawningEnemy;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnNext", interval, interval);
        spawningEnemy = wave.GetWave();
    }
	
	// Update is called once per frame
	void SpawnNext () {
             
        Instantiate(spwanEnemy, transform.position, Quaternion.identity);
        if (--spawningEnemy[0] == 0)
        {
            CancelInvoke("SpawnNext");
        }
        
    }
}
