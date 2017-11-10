using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {
    int currentWave = 1;
    // Use this for initialization

    void Start () {
        switch (currentWave)
        {
            case 1:

                currentWave++;
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
