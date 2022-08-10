using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferencesHolder : MonoSingleton<ReferencesHolder>
{
    [Header("Scriptable Objects")]
    [Space]
    [SerializeField] private List<CharacterParametersSO> characterParametersSOList = new List<CharacterParametersSO>();

    public List<CharacterParametersSO> CharacterParametersSOList { get => characterParametersSOList; }
}
