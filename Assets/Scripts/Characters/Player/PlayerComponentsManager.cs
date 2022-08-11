using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponentsManager : MonoBehaviour
{
    [Header("References")]
    [Space]
    [SerializeField] private PlayerModelsHolder modelsHolder;

    private PlayerAnimationManager animationManager;

    private void Awake()
    {
        animationManager = GetComponent<PlayerAnimationManager>();
    }

    private void Start()
    {
        MainUI.Instance.OnCharacterChoosen += MainUI_CharacterChoosen_Reaction;

        BattleUI.Instance.OnAttackButtonPressed += BattleUI_AttackButtonPressed_Reaction;
        BattleUI.Instance.OnGuardButtonPressed += BattleUI_GuardButtonPressed_Reaction;
        BattleUI.Instance.OnHealButtonPressed += BattleUI_HealButtonPressed_Reaction;
    }

    private void OnDestroy()
    {
        if(MainUI.Instance)
        {
            MainUI.Instance.OnCharacterChoosen -= MainUI_CharacterChoosen_Reaction;
        }
        if(BattleUI.Instance)
        {
            BattleUI.Instance.OnAttackButtonPressed -= BattleUI_AttackButtonPressed_Reaction;
            BattleUI.Instance.OnGuardButtonPressed -= BattleUI_GuardButtonPressed_Reaction;
            BattleUI.Instance.OnHealButtonPressed -= BattleUI_HealButtonPressed_Reaction;
        }
    }

    private void MainUI_CharacterChoosen_Reaction(Characters character)
    {
        modelsHolder.SetCharacterModel(character);
        animationManager = modelsHolder.CurrentModel.GetComponent<PlayerAnimationManager>();
    }

    private void BattleUI_AttackButtonPressed_Reaction()
    {
        animationManager.SetAttackState();
    }

    private void BattleUI_GuardButtonPressed_Reaction()
    {
        animationManager.SetGuardState();
    }

    private void BattleUI_HealButtonPressed_Reaction()
    {
        animationManager.SetHealState();
    }
}
