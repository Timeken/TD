using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour {

    [SerializeField]
    Button continueButton, exitButton;
    [SerializeField]
    Slider musicVolumeSlider, soundVolumeSlider;
    [SerializeField]
    GameObject optionsMenu;
    [SerializeField]
    private AudioSource optionsButtonsClickSound;

    [SerializeField]
    IngameButtons mybuttons;

    public void ContinueButtonClick()
    {
        GameObject button = GameObject.FindGameObjectWithTag("UI");
        mybuttons = button.GetComponent<IngameButtons>();
        mybuttons.PlayButtonSound();
        //optionsButtonsClickSound.Play();
        optionsMenu.gameObject.SetActive(false);
        Time.timeScale = 1; // Starts the game again when Continue is pressed.
        print("Continue Button pressed.");
    }

    public void ExitButtonClick()
    {
        optionsButtonsClickSound.Play();
        print("Exit Button pressed.");
    }
}
