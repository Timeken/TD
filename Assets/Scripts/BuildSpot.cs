using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSpot : MonoBehaviour
{

    public GameObject Turret;
    public GameObject TurretTemp;
    GameObject DestroyTemp;

    IngameButtons ingameButtons;
    PlayerHandler playerHandler;

    Ray ray;
    RaycastHit hit;
    bool Buildt = false;

    int baseTurretCost = 50;

    private void Start()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("UI");
        ingameButtons = gameObject.GetComponent<IngameButtons>();

        gameObject = GameObject.FindGameObjectWithTag("MainCamera");
        playerHandler = gameObject.GetComponent<PlayerHandler>();
    }

    void OnMouseUpAsButton()
    {
        if (ingameButtons.canBuild && playerHandler.dollarValue >= baseTurretCost)
        {
            playerHandler.dollarValue -= baseTurretCost;
            GameObject gameObject = Instantiate(Turret);
            gameObject.transform.position = transform.position;
            Destroy(DestroyTemp);
            Buildt = true;
            ingameButtons.canBuild = false;
        }
    }
    private void OnMouseEnter()
    {
        if (!Buildt && ingameButtons.canBuild)
        {
            Debug.Log(ingameButtons.canBuild);
            DestroyTemp = Instantiate(TurretTemp);
            DestroyTemp.transform.position = transform.position;
        }
    }
    private void OnMouseExit()
    {
        Destroy(DestroyTemp);
    }

}
