using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreenUI : MonoBehaviour {

    public Button aboutButton;
    public Button aboutExitButton;

    public GameObject aboutPanel;

	// Use this for initialization
	void Start () {
        aboutPanel.gameObject.SetActive(false);
	}
	
	public void aboutButtonPressed()
    {
        aboutPanel.gameObject.SetActive(true);
    }

    public void aboutExitButtonPressed()
    {
        aboutPanel.gameObject.SetActive(false);
    }
}
