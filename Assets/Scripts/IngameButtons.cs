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
    public GameObject winScreen;


    public GameObject TurretUpgrade1;
    public GameObject TurretUpgrade2;

    private GameObject TurretSelected;
    private string TurretType;



    public GameObject gameOverWindow;
    private bool isShowing;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("MainCamera");
        playerHandler = gameObject.GetComponent<PlayerHandler>();

        //gameOverWindow.gameObject.SetActive(false); // Game Over window is not visible at start.
        upgradeMenu.gameObject.SetActive(false); //Upgrade menu is not visible at start.
        optionsMenu.gameObject.SetActive(false); // Options menu is not visible at start.
        winScreen.gameObject.SetActive(false); // Win screen not visible at start.


        playerGold.text = playerHandler.dollarValue.ToString() + " Space dollars";
    }

    private void Update()
    {
        playerGold.text = playerHandler.dollarValue.ToString() + " Space dollars";

        if (playerHandler.dollarValue == 1)
        {
            playerGold.text = playerHandler.dollarValue.ToString() + " Space dollar"; // Grammar!!!
        }
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
        Time.timeScale = 0; // Pauses the game while the Options window is open. 
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
    //public bool TurretUpgrade(GameObject turret)

        TurretSelected = turret;
        TurretType = turretType;
        bool canUpgrade = false;
        upgradeMenu.gameObject.SetActive(true);

        return canUpgrade;
    }

}
