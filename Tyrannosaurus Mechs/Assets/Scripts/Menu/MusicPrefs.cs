using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Slider))]
public class MusicPrefs : MonoBehaviour
{
    const string MusicVolPrefs = "_Music";

    [SerializeField]
    private Slider music_Slider;

    void Awake()
    {
        music_Slider = GetComponent<Slider>();

        music_Slider.onValueChanged.AddListener(new UnityAction<float>(index =>
        {
            PlayerPrefs.SetFloat(MusicVolPrefs, music_Slider.value);
            PlayerPrefs.Save();
        }));
    }

    void Start()
    {
        music_Slider.value = PlayerPrefs.GetFloat(MusicVolPrefs, 0);
    }
}
