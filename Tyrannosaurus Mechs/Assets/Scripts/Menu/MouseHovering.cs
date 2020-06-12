using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MouseHovering : MonoBehaviour
{
    public AudioClip myButtonClick;
    public AudioClip pointerDown;

    public AudioSource AudioSrc;

    //public GameObject _Open;

    public void Hovering()
    {
        AudioSrc.PlayOneShot(myButtonClick);

        //_Open.SetActive(true);
    }

    public void OffHovering()
    {
        //_Open.SetActive(false);
    }

    public void HoverPressed()
    {
        //_Open.SetActive(false);
    }

    public void ButtonDown()
    {
        AudioSrc.PlayOneShot(pointerDown);
    }
}
