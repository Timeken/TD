using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngameButtons : MonoBehaviour {

    public static IngameButtons instance;
    private BuildSpot buildSpot;
    PlayerHandler playerHandler;

    [SerializeField]
    private AudioSource buttonClickSound;

    [SerializeField]
    private Text playerGold;
    public Button buildCancelButton;
    private Button speedButton;
    [SerializeField]
    private Image speedButtonImage;
    [SerializeField]
    private Sprite speedUpSprite, normalSpeedSprite;

    public bool canBuild;
    private bool optionsButtonPressed;
    private bool isShowing;
    private bool normalTime;

    public float TurretUpgrade1Cost = 50, TurretUpgrade2Cost = 150;

    public GameObject upgradeMenu;
    public GameObject optionsMenu;
    public GameObject winScreen;

    public GameObject TurretUpgrade1;
    public GameObject TurretUpgrade2;
    private GameObject TurretSelected;

    private string TurretType;

    private void Awake()
    {
        instance = this;
        normalTime = true;
    }

    private void Start()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("MainCamera");
        playerHandler = gameObject.GetComponent<PlayerHandler>();
        buttonClickSound.volume = 0.3f;

        upgradeMenu.gameObject.SetActive(false); //Upgrade menu is not visible at start.
        optionsMenu.gameObject.SetActive(false); // Options menu is not visible at start.
        winScreen.gameObject.SetActive(false); // Win screen not visible at start.
        buildCancelButton.gameObject.SetActive(false); // Cancel button when building is not visible at start.

        playerGold.text = playerHandler.dollarValue.ToString();
        Time.timeScale = 1;
    }

    public void Update()
    {
        playerGold.text = playerHandler.dollarValue.ToString();
    }

    public void PlayButtonSound()
    {
        buttonClickSound.Play();
    }

    public void BuildButtonClick()
    {
        PlayButtonSound();
        canBuild = true;
        Debug.Log("Build Button pressed.");
        upgradeMenu.gameObject.SetActive(false);
        buildCancelButton.gameObject.SetActive(true); // cancel button becomes active.
    }

    public void buildCancelButtonClick()
    {
        PlayButtonSound();
        canBuild = false;       
        buildCancelButton.gameObject.SetActive(false);
    }

    public void OptionsButtonClick()
    {
        PlayButtonSound();
        optionsButtonPressed = true;
        optionsMenu.gameObject.SetActive(true);
        Time.timeScale = 0; // Pauses the game while the Options window is open. 
        print("Options Button pressed.");
    }

    public void SpeedUpButtonClick()
    {
        normalTime = !normalTime;
        PlayButtonSound();

        if (normalTime == true)
        {
            Time.timeScale = 1;
            print("Speed is normal.");
            speedButtonImage.sprite = speedUpSprite;
        }

        if (normalTime == false)
        {
            Time.timeScale = 2;
            print("Speed x2");
            speedButtonImage.sprite = normalSpeedSprite;
        }
    }

    public void Upgrade1ButtonClick()
    {
        PlayButtonSound();

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
        PlayButtonSound();

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
