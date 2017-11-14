using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minion1 : Enemy {

    public Slider Minion1HpBar;
    int currentHP;
    bool isDamaged = false;
    Color damagedColor = new Color(255f, 0f, 0f, 0.6f);

    void Start()
    {
        Minion1HpBar.value = CalculateDamage();
    }

    void Update()
    {
        /*if (Input.GetKey(KeyCode.X))
        {
            TakeDamage(3);  // Trying to make the HP bar do its thing
        }*/

        if(isDamaged)
        {
            //work in progress
        }

    }
    public void SetValues(int hp, int damage)
    {
        this.FullHP = hp;
        this.DMG = damage;
    }

    public void TakeDamage(int enemydamage) // Gets called every time the minion takes damage.
    {
        FullHP = currentHP;
        currentHP -= enemydamage;
        Minion1HpBar.value = CalculateDamage();

    }

    int CalculateDamage()
    {
        if (FullHP == 0)
        {
            return 0;
        }
        return currentHP / FullHP; // Gets us the % HP left.
    }
}
