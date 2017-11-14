using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion2 : Enemy
{
    public void SetValues(int hp, int damage)
    {
        this.FullHP = hp;
        this.DMG = damage;
    }
}
