using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSpot : MonoBehaviour {

    public GameObject Turret;
    public GameObject TurretTemp;
    GameObject DestroyTemp;

    Ray ray;
    RaycastHit hit;
    bool Buildt = false;

    void OnMouseUpAsButton()
    {
        GameObject gameObject = Instantiate(Turret);
        gameObject.transform.position = transform.position;
        Destroy(DestroyTemp);
        Buildt = true;
    }
    private void OnMouseEnter()
    {
        if (!Buildt)
        {
            DestroyTemp = Instantiate(TurretTemp);
            DestroyTemp.transform.position = transform.position;
        }
    }
    private void OnMouseExit()
    {
        Destroy(DestroyTemp);
    }

}
