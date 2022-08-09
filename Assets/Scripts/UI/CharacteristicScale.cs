using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacteristicScale : MonoBehaviour
{
    [Header("References")]
    [Space]
    [SerializeField] private TextMeshProUGUI valueText;
    [SerializeField] private Slider slider;

    private const float SliderValueMultiplier = 100f;

    public void UpdateValueText()
    {
        valueText.text = (slider.value * SliderValueMultiplier).ToString();
    }
}
