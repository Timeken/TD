using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHandler : MonoBehaviour {

    public List<Enemy> enemyList = new List<Enemy>(); 

    public Enemy CreateEnemy(int hp, int dmg) 
    {
        Enemy newEnemy = new Enemy();
        newEnemy.FullHP = hp;
        newEnemy.DMG = dmg;
        return newEnemy;
    }

    void Start () {
        enemyList = new List<Enemy>(); 
        enemyList.Add(CreateEnemy(100, 5)); 
        enemyList.Add(CreateEnemy(200, 4));
    }
}
