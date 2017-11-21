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


    public GameObject upgradeMenu;
    public GameObject optionsMenu;
    private bool isShowing;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("MainCamera");
        playerHandler = gameObject.GetComponent<PlayerHandler>();
        
        upgradeMenu.gameObject.SetActive(false); //Upgrade menu is not visible at start.
        optionsMenu.gameObject.SetActive(false); // Options menu is not visible at start.

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
        Time.timeScale = 0; // Pauses the game while the Options window is open. 
        print("Options Button pressed.");
    }


    public bool TurretUpgrade(GameObject turret)
    {
        bool canUpgrade = false;
        Debug.Log("Activate");
        upgradeMenu.gameObject.SetActive(true);

        return canUpgrade;
    }

}
