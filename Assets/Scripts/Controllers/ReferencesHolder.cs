using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferencesHolder : MonoSingleton<ReferencesHolder>
{
    [Header("Scriptable Objects")]
    [Space]
    [SerializeField] private CharacterParametersSO ursaParametersSO;
    [SerializeField] private CharacterParametersSO skywrathMageParametersSO;
    [SerializeField] private CharacterParametersSO necrophosParametersSO;

    public CharacterParametersSO UrsaParametersSO { get => ursaParametersSO; }
    public CharacterParametersSO SkywrathMageParametersSO { get => skywrathMageParametersSO; }
    public CharacterParametersSO NecrophosParametersSO { get => necrophosParametersSO; }
}
