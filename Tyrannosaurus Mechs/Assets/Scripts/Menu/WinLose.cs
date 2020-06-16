using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLose : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject _MusicPlayer;
   
    //Audio
    AudioSource audSrc;
    public AudioClip _winClip;
    public AudioClip _loseClip;

    // Start is called before the first frame update
    void Start()
    {
        winScreen = GameObject.Find("WinScreen");
        loseScreen = GameObject.Find("LoseScreen");
        _MusicPlayer = GameObject.Find("MusicPlayer");
        audSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (winScreen.activeInHierarchy == true)
        {
            audSrc.PlayOneShot(_winClip, 2f);
            _MusicPlayer.SetActive(false);
        }

        if(loseScreen.activeInHierarchy == true)
        {
            audSrc.PlayOneShot(_loseClip, 2f);
            _MusicPlayer.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Keypad8))
        {
            winScreen.SetActive(true);
            Time.timeScale = 1f;
        }

        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            loseScreen.SetActive(true);
            Time.timeScale = 1f;
        }
    }
}
