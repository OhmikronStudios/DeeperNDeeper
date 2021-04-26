using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    public AudioManager AM;

    public Slider MasterVolumeSlider;
    public Slider MusicVolumeSlider;
    public Slider SFXVolumeSlider;
    float currentMasterVolume;
    float currentMusicVolume;
    float currentSFXVolume;

    // Start is called before the first frame update
    void Start()
    {
        AM = FindObjectOfType<AudioManager>();

        //If player preferences exist, set their settings.
        LoadSettings();
    }

    //Setter functions for settings values.
    public void SetMasterVolume(float volume)
    {
        AM.SetGroupVolume("Master", volume);
        currentMasterVolume = volume;
    }
    public void SetMusicVolume(float volume)
    {
        AM.SetGroupVolume("Music", volume);
        currentMusicVolume = volume;
    }
    public void SetSFXVolume(float volume)
    {
        AM.SetGroupVolume("SFX", volume);
        currentSFXVolume = volume;
    }

    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }



    public void SaveSettings()  //Save the current setting values to the player preferences
    {

        PlayerPrefs.SetFloat("MasterVolumePreference", currentMasterVolume); Debug.Log("MasterVolumePreference:" + currentMasterVolume);
        PlayerPrefs.SetFloat("MusicVolumePreference", currentMusicVolume); Debug.Log("MusicVolumePreference:" + currentMusicVolume);
        PlayerPrefs.SetFloat("SFXVolumePreference", currentSFXVolume); Debug.Log("SFXVolumePreference:" + currentSFXVolume);

    }

    public void LoadSettings() //Called at start based on the player preferences
    {
        LoadAudioLevels();
    }

    public void LoadAudioLevels()
    {
        if (PlayerPrefs.HasKey("MasterVolumePreference"))
        {
            MasterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolumePreference");
            AM.SetGroupVolume("Master", MasterVolumeSlider.value);
        }
        else
            MasterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolumePreference");

        if (PlayerPrefs.HasKey("MusicVolumePreference"))
        {
            MusicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolumePreference");
            AM.SetGroupVolume("Music", MusicVolumeSlider.value);
        }
        else
            MusicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolumePreference");

        if (PlayerPrefs.HasKey("SFXVolumePreference"))
        {
            SFXVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolumePreference");
            AM.SetGroupVolume("SFX", SFXVolumeSlider.value);
        }
        else
            SFXVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolumePreference");


    }


}