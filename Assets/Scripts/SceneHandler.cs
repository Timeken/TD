using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour {

	public void changeMyScene(int sceneToChangeTo)
    {
        SceneManager.LoadScene(sceneToChangeTo);     
    }

    public void quitGame()
    {
        Application.Quit(); 
        //Only used on Exit buttons, as it completely shuts off the game. Does not work in Unity and is not supposed to. 
        // To test this, Build the game first. :)
    }

}
