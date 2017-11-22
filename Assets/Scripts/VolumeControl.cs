using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour {

    public Slider musicVolumeSlider;
    public AudioSource musicSource;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        musicSource.volume = musicVolumeSlider.value;
	}
}
