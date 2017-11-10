using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[System.Serializable] Just testing this out, doesn't seem to be doing anything 

public class EnemyHandler : MonoBehaviour {

    public List<Enemy> enemyList = new List<Enemy>(); // This puts all objects which inherits from Enemy in a list!

    public Enemy CreateEnemy(int hp, int dmg) 
    // Are used to create a new enemy. This needs to be called somewhere with two numbers which corresponds to the object's HP and DMG.
    {
        Enemy newEnemy = new Enemy();
        newEnemy.HP = hp;
        newEnemy.DMG = dmg;
        return newEnemy;
    }

    void Start () {
        enemyList = new List<Enemy>(); // This creates the list we see in the Inspector. It's empty until we .Add something to it.
        enemyList.Add(CreateEnemy(100, 5)); 
        enemyList.Add(CreateEnemy(200, 4));
    }
	

	void Update () {

    }
}
