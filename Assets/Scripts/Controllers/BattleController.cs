using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoSingleton<BattleController>
{
    [Header("Turns Data")]
    [Space]
    [SerializeField] private int currentTurnNumber = 1;

    private bool playerTurn = false;

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

    #region Events Reaction Methods
    private void MainUI_CharacterChoosen_Reaction(Characters _)
    {
        playerTurn = true;
        BattleUI.Instance.UpdateTurnText(currentTurnNumber);
    }

    private void BattleUI_AttackButtonPressed_Reaction()
    {
        Debug.Log($"Attack");
    }

    private void BattleUI_GuardButtonPressed_Reaction()
    {
        Debug.Log($"Guard");
    }

    private void BattleUI_HealButtonPressed_Reaction()
    {
        Debug.Log($"Heal");
    }
    #endregion Events Reaction Methods
}
