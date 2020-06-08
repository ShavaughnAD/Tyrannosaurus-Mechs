using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Slider))]
public class MasterPrefs : MonoBehaviour
{
    const string MastVolPrefs = "_Master";

    [SerializeField]
    private Slider mast_Slider;

    void Awake()
    {
        mast_Slider = GetComponent<Slider>();

        mast_Slider.onValueChanged.AddListener(new UnityAction<float>(index =>
        {
            PlayerPrefs.SetFloat(MastVolPrefs, mast_Slider.value);
            PlayerPrefs.Save();
        }));
    }

    void Start()
    {
        mast_Slider.value = PlayerPrefs.GetFloat(MastVolPrefs, 0);
    }
}
