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

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("MainCamera");
        playerHandler = gameObject.GetComponent<PlayerHandler>();


        playerGold.text = playerHandler.gold.ToString() + " Gold";
    }

    private void Update()
    {
        playerGold.text = playerHandler.gold.ToString() + " Gold";
    }

    public void BuildButtonClick()
    {
        canBuild = true;
        Debug.Log("Presed");
	}

}
