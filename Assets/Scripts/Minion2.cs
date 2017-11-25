using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion2 : Enemy
{
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
