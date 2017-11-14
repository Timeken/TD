using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hpbar : MonoBehaviour
{
    public Slider HPslider;
    public Minion1 minion;

    public int minionHP
    {
        get { return minion.FullHP; }
        set { minion.FullHP = value; }
    }

    public void Test()
    {
    }
}
