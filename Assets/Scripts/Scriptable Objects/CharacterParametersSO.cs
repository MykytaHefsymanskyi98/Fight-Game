using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterParametersSO", menuName = "ScriptableObjects/CharacterParametersSO", order = 1)]
public class CharacterParametersSO : ScriptableObject
{
    [Header("Character Parameters")]
    [Space]
    [Range(0, 100f)] [SerializeReference] private float damageAmount = 1f;
    [Range(0, 100f)] [SerializeReference] private float healthAmount = 1f;
    [SerializeReference] private bool chanceToDecreaseIncomingDamage = false;
    [SerializeReference] private bool chanceToIncreaseDamageDealt = false;

    public float DamageAmount { get => damageAmount; }
    public float HealthAmount { get => healthAmount; }
    public bool ChanceToDecreaseIncomingDamage { get => chanceToDecreaseIncomingDamage; }
    public bool ChanceToIncreaseDamageDealt { get => chanceToIncreaseDamageDealt; }
}
