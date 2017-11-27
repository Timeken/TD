using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBarUpgrade1 : MonoBehaviour {

    [SerializeField]
    private Slider ammoSlider;
    TurretUpgrade1 myTower;

    void Start()
    {
        myTower = GetComponent<TurretUpgrade1>();
        ammoSlider.maxValue = myTower.ammoMax;
        ammoSlider.minValue = 0;

    }

    void Update()
    {
        transform.rotation = Quaternion.identity;
        ammoSlider.value = myTower.ammo;
    }
}
