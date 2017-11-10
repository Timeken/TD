using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject spwanEnemy;

    public float interval = 2;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnNext", interval, interval);
    }
	
	// Update is called once per frame
	void SpawnNext () {
        Instantiate(spwanEnemy, transform.position, Quaternion.identity);
    }
}
