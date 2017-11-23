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
        //This is only used on the Exit button in Scene 0, because it closes the game completely.
    }

}
