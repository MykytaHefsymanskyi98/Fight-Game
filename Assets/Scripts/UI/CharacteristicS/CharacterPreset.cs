using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPreset : MonoBehaviour
{
    [Header("Character Data")]
    [Space]
    [SerializeField] private Characters characterType = Characters.Ursa;
    [Space]
    [SerializeField] private Slider damageSlider;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Toggle decreaseChanceOfIncDamageToggle;
    [SerializeField] private Toggle increaseChanceOfDamageDealtToggle;
    [Space]
    [SerializeField] private Image characterIcon;

    private void Start()
    {
        for(int i = 0; i < ReferencesHolder.Instance.CharacterParametersSOList.Count; i++)
        {
            if(ReferencesHolder.Instance.CharacterParametersSOList[i].Character == characterType)
            {
                SetCharacterParameters(ReferencesHolder.Instance.CharacterParametersSOList[i]); 
            }
        }
    }

    public void ConfirmButtonPressed()
    {
        MainUI.Instance.CharacterChoosenCommand(characterType);
    }

    private void SetCharacterParameters(CharacterParametersSO parametersSO)
    {
        damageSlider.value = parametersSO.DamageAmount;
        healthSlider.value = parametersSO.HealthAmount;
        decreaseChanceOfIncDamageToggle.isOn = parametersSO.ChanceToDecreaseIncomingDamage;
        increaseChanceOfDamageDealtToggle.isOn = parametersSO.ChanceToIncreaseDamageDealt;
    }
}
