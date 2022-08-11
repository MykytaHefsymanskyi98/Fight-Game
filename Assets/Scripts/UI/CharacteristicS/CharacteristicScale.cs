using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacteristicScale : MonoBehaviour
{
    [Header("Slider")]
    [Space]
    [SerializeField] private Characteristics characteristic = Characteristics.Value;
    [Header("References")]
    [Space]
    [SerializeField] private TextMeshProUGUI valueText;
    [SerializeField] private Slider slider;

    public void UpdateValueText()
    {
        if(characteristic == Characteristics.Value)
        {
            valueText.text = slider.value.ToString();
        }
        else
        {
            valueText.text = ($"{slider.value} %").ToString();
        }
    }
}
