using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class SCR_Scripting : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private PostProcessProfile postPro;

    private void Awake()
    {
        
    }

    private void Start()
    {
        slider.onValueChanged.AddListener(delegate { ChangeBrightness(slider.value); });
    }

    private void ChangeBrightness(float value)
    {
        postPro.GetSetting<ColorGrading>().postExposure.Override(value);
    }
}
