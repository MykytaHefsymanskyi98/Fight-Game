using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [Header("Combat Data")]
    [Space]
    [SerializeField] private float damageAmount = 10f;
    [SerializeField] private float startHealthAmount = 10f;
    [SerializeField] private float currentHealthAmount = 10f;
    [SerializeField] private float decreaseDamageChance = 10f;
    [SerializeField] private float doubleDamageDealtChance = 10f;

    public float DamageAmount { get => damageAmount; set => damageAmount = value; }
    public float StartHealthAmount { get => startHealthAmount; set => startHealthAmount = value; }
    public float CurrentHealthAmount { get => currentHealthAmount; set => currentHealthAmount = value; }
    public float DecreaseDamageChance { get => decreaseDamageChance; set => decreaseDamageChance = value; }
    public float DoubleDamageDealtChance { get => doubleDamageDealtChance; set => doubleDamageDealtChance = value; }

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
        DamageAmount = parametersSO.DamageAmount;
        StartHealthAmount = parametersSO.HealthAmount;
        CurrentHealthAmount = StartHealthAmount;
        DecreaseDamageChance = parametersSO.ChanceToDecreaseIncomingDamage;
        DoubleDamageDealtChance = parametersSO.ChanceToIncreaseDamageDealt;
    }
}
