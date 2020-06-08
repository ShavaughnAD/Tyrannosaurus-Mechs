using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("_SFX", Mathf.Log10(volume) * 20);
    }

    //Using the AudioMixer MusicVolume
    public void SetTheMusicVolume(float music_volume)
    {
        audioMixer.SetFloat("_Music", Mathf.Log10(music_volume) * 20);
    }

    //Using the AudioMixer Master Volume 
    public void SetMasterVolume(float m_volume)
    {
        audioMixer.SetFloat("_Master", Mathf.Log10(m_volume) * 20);
    }
}
