using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minion1 : Enemy {

    bool isDamaged = false;
    Color damagedColor = new Color(255f, 0f, 0f, 0.6f);

    GameObject enemy;

    public void SetValues(float hp, float damage, int value)
    {
        this.FullHP = hp;
        this.DMG = damage;
        this.dollarValue = value;
    }

    public float EnemyGetDMG()
    {
        return DMG;
    }

}
