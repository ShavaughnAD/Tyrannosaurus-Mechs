using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScene : MonoBehaviour
{
    public float _time;
    public int totalTime;

    public bool _isCredits = false;

    public GameObject main;
    public GameObject credits;

    void Update()
    {
        if(_isCredits == true)
        {
            _time += Time.deltaTime;
        }

        if(_time >= totalTime)
        {
            _time = 0f;
            _isCredits = false;
            main.SetActive(true);
            credits.SetActive(false);
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            _time = 0f;
            _isCredits = false;
            main.SetActive(true);
            credits.SetActive(false);
        }
    }

    public void TrueCredits()
    {
        _isCredits = true;
    }
}
