using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {
    int currentWave = 1;
    // Use this for initialization

    void Start () {

	}

    public int[] GetWave()
    {
        int[] enemyTypes = new int[2];
        switch (currentWave)
        {
            case 1:
                enemyTypes[0] = 10;
                currentWave++;
                break;

            case 2:
                enemyTypes[0] = 13;
                enemyTypes[1] = 2;
                currentWave++;
                break;
        }
        return enemyTypes;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
