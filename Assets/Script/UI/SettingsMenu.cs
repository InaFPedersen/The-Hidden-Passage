using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SettingsMenu : MonoBehaviour
{
    //Variables/Refrences
    [Header("Audio")]
    public AudioMixer audioMixer;

    //function to controll volum of sound
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    //Function to controll graphic settings
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
