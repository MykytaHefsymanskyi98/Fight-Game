using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatManager : MonoBehaviour
{
    [Header("Combat Data")]
    [Space]
    [SerializeField] private float damageAmount = 10f;
    [SerializeField] private float startHealthAmount = 10f;
    [SerializeField] private float currentHealthAmount = 10f;
    [SerializeField] private float decreaseDamageChance = 10f;
    [SerializeField] private float doubleDamageDealtChance = 10f;

    public void SetCharacterCombatData(Characters character)
    {
        for (int i = 0; i < ReferencesHolder.Instance.CharacterParametersSOList.Count; i++)
        {
            if (ReferencesHolder.Instance.CharacterParametersSOList[i].Character == character)
            {
                SetCharacterParameters(ReferencesHolder.Instance.CharacterParametersSOList[i]);
            }
        }
    }

    private void SetCharacterParameters(CharacterParametersSO parametersSO)
    {
        damageAmount = parametersSO.DamageAmount;
        startHealthAmount = parametersSO.HealthAmount;
        currentHealthAmount = startHealthAmount;
        decreaseDamageChance = parametersSO.ChanceToDecreaseIncomingDamage;
        doubleDamageDealtChance = parametersSO.ChanceToIncreaseDamageDealt;
    }

    public float GetDamageDealt()
    {
        float currentDamage = 0f;
        currentDamage = damageAmount;

        return currentDamage;
    }
}
