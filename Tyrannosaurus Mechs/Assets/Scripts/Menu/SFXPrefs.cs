using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Slider))]
public class SFXPrefs : MonoBehaviour
{
    const string SFXVolume = "_SFX";

    [SerializeField]
    private Slider SFX_Slider;

    void Awake()
    {
        SFX_Slider = GetComponent<Slider>();

        SFX_Slider.onValueChanged.AddListener(new UnityAction<float>(index =>
        {
            PlayerPrefs.SetFloat(SFXVolume, SFX_Slider.value);
            PlayerPrefs.Save();
        }));
    }

    void Start()
    {
        SFX_Slider.value = PlayerPrefs.GetFloat(SFXVolume, 0);
    }
}
