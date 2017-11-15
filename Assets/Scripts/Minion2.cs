﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion2 : Enemy
{
    bool isDamaged = false;
    Color damagedColor = new Color(255f, 0f, 0f, 0.6f);

    public void SetValues(int hp, int damage, int value)
    {
        this.FullHP = hp;
        this.DMG = damage;
        this.dollarValue = value;
    }
}
