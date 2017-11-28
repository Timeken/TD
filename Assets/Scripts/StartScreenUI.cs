using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreenUI : MonoBehaviour {

    [SerializeField]
    private Button aboutButton, aboutExitButton;
    [SerializeField]
    private GameObject aboutPanel;
    [SerializeField]
    private AudioSource startScreenButtonSound;


    void Start () {
        startScreenButtonSound.volume = 0.5f;
        aboutPanel.gameObject.SetActive(false);
	}
	
	public void aboutButtonPressed()
    {
        startScreenButtonSound.Play();
        aboutPanel.gameObject.SetActive(true);
    }

    public void aboutExitButtonPressed()
    {
        startScreenButtonSound.Play();
        aboutPanel.gameObject.SetActive(false);
    }
}
