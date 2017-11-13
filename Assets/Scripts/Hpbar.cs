using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hpbar : MonoBehaviour
{

    public Minion1 minion;
    public int minionHP
    {
        get { return minion.HP; }
        set { minion.HP = value; }
    }

    public void Test()
    {
    }
}
