using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

    public int[] GetWave(int currentWave)
    {
        int[] enemyTypes = new int[5];

        switch (currentWave)
        {
            case 1:
                enemyTypes[0] = 10;
                break;

            case 2:
                enemyTypes[0] = 13;
                enemyTypes[1] = 2;
                break;
            case 3:
                enemyTypes[0] = 10;
                enemyTypes[1] = 5;
                break;
            case 4:
                enemyTypes[0] = 10;
                enemyTypes[1] = 10;
                break;
            case 5:
                enemyTypes[1] = 20;
                break;
        }
        return enemyTypes;
    }

}
