using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterModel : MonoBehaviour
{
    [Header("Character Type")]
    [Space]
    [SerializeField] private Characters characterType;

    public Characters CharacterType { get => characterType; }
}
