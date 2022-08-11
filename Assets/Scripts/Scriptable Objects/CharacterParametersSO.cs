using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterParametersSO", menuName = "ScriptableObjects/CharacterParametersSO", order = 1)]
public class CharacterParametersSO : ScriptableObject
{
    [Header("Character")]
    [Space]
    [SerializeReference] private Characters character;
    [Header("Character Parameters")]
    [Space]
    [Range(0, 100f)] [SerializeReference] private float damageAmount = 1f;
    [Range(0, 100f)] [SerializeReference] private float healthAmount = 1f;
    [Range(0, 100f)] [SerializeReference] private float chanceToDecreaseIncomingDamage = 1f;
    [Range(0, 100f)] [SerializeReference] private float chanceToIncreaseDamageDealt = 1f;

    public float DamageAmount { get => damageAmount; }
    public float HealthAmount { get => healthAmount; }
    public float ChanceToDecreaseIncomingDamage { get => chanceToDecreaseIncomingDamage; }
    public float ChanceToIncreaseDamageDealt { get => chanceToIncreaseDamageDealt; }

    public Characters Character { get => character; }
}
