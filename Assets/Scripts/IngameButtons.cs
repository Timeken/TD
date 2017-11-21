using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameButtons : MonoBehaviour {

    public static IngameButtons instance;
    private BuildSpot buildSpot;
    PlayerHandler playerHandler;

    public Text playerGold;
    public bool canBuild;
    public bool optionsButtonPressed;

    public float TurretUpgrade1Cost = 50, TurretUpgrade2Cost = 150;

    public GameObject upgradeMenu;
    public GameObject optionsMenu;

    public GameObject TurretUpgrade1;
    public GameObject TurretUpgrade2;

    private GameObject TurretSelected;
    private string TurretType;

    //private bool isShowing;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("MainCamera");
        playerHandler = gameObject.GetComponent<PlayerHandler>();
        
        upgradeMenu.gameObject.SetActive(false);
        optionsMenu.SetActive(false);

        playerGold.text = playerHandler.dollarValue.ToString() + " Space dollar";
    }

    private void Update()
    {
        playerGold.text = playerHandler.dollarValue.ToString() + " Space dollar";
    }

    public void BuildButtonClick()
    {
        canBuild = true;
        Debug.Log("Build Button pressed.");
	}

    public void OptionsButtonClick()
    {
        optionsButtonPressed = true;
        optionsMenu.gameObject.SetActive(true);
        print("Options Button pressed.");


    }

    public void Upgrade1ButtonClick()
    {

        switch (TurretType)
        {
            case "turretBase":
                if (playerHandler.dollarValue >= TurretUpgrade1Cost)
                {
                    playerHandler.dollarValue -= TurretUpgrade1Cost;
                    GameObject gameObject = Instantiate(TurretUpgrade1);
                    gameObject.transform.position = TurretSelected.transform.position;
                    Destroy(TurretSelected);
                }
                break;
        }
        upgradeMenu.gameObject.SetActive(false);
    }

    public void Upgrade2ButtonClick()
    {

        switch (TurretType)
        {
            case "turretBase":
                if (playerHandler.dollarValue >= TurretUpgrade2Cost)
                {
                    playerHandler.dollarValue -= TurretUpgrade2Cost;
                    GameObject gameObject = Instantiate(TurretUpgrade2);
                    gameObject.transform.position = TurretSelected.transform.position;
                    Destroy(TurretSelected);
                }
                break;
        }
        upgradeMenu.gameObject.SetActive(false);
    }

    public bool TurretUpgrade(GameObject turret, string turretType)
    {
        TurretSelected = turret;
        TurretType = turretType;
        bool canUpgrade = false;
        upgradeMenu.gameObject.SetActive(true);

        return canUpgrade;
    }

}
