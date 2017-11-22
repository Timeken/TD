using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour {

    public Slider musicVolumeSlider;
    public Slider soundVolumeSlider;
    public AudioSource musicSource;
    public AudioSource soundSource;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        musicSource.volume = musicVolumeSlider.value;

        //soundSource.volume = soundVolumeSlider.value;
	}

   /* public void GetSoundSource()
    {
        soundSource.Play();
    }*/
}
