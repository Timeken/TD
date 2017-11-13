using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion1 : Enemy {
    public void SetValues(int hp, int damage)
    {
        this.HP = hp;
        this.DMG = damage;
    }
}
