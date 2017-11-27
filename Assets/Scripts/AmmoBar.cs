using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBar : MonoBehaviour {

    [SerializeField]
    private Slider ammoSlider;
    TowerBase myTower;

	void Start () {
        myTower = GetComponent<TowerBase>();
        ammoSlider.maxValue = myTower.ammoMax;
        ammoSlider.minValue = 0;

	}
	
	void Update () {
        transform.rotation = Quaternion.identity;
        ammoSlider.value = myTower.ammo;
	}
}
