using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponentsManager : MonoBehaviour
{
    [Header("References")]
    [Space]
    [SerializeField] private PlayerModelsHolder modelsHolder;

    private void Start()
    {
        MainUI.Instance.OnCharacterChoosen += MainUI_CharacterChoosen_Reaction;
    }

    private void OnDestroy()
    {
        if(MainUI.Instance)
        {
            MainUI.Instance.OnCharacterChoosen -= MainUI_CharacterChoosen_Reaction;
        }
    }

    private void MainUI_CharacterChoosen_Reaction(Characters character)
    {
        modelsHolder.SetCharacterModel(character);
    }
}
