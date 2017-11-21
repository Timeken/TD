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


    public void ContinueButtonClick()
    {
        optionsMenu.gameObject.SetActive(false);
        Time.timeScale = 1; // Starts the game again when Continue is pressed.
        print("Continue Button pressed.");
    }

    public void ExitButtonClick()
    {
        // To do: Make so that when the exit button is pressed, Start Screen will activate.
        print("Exit Button pressed.");
    }
}
