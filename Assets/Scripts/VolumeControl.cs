using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{

    public Slider musicVolumeSlider;
    public Slider soundVolumeSlider;
    public AudioSource musicSource;


    void Update()
    {
        musicSource.volume = musicVolumeSlider.value;

        if (GameObject.FindGameObjectWithTag("Turret") != null) // I hope this isn't too ugly.
        {
            if (FindObjectOfType<TowerBase>() != null)
            {
                FindObjectOfType<TowerBase>().setMyVolume(soundVolumeSlider.value);
            }
            if (FindObjectOfType<TurretUpgrade1>() != null)
            {
                FindObjectOfType<TurretUpgrade1>().setMyVolume(soundVolumeSlider.value);
            }
            if (FindObjectOfType<TurretUpgrade2>() != null)
            {
                FindObjectOfType<TurretUpgrade2>().setMyVolume(soundVolumeSlider.value);
            }

        }


    }
}
