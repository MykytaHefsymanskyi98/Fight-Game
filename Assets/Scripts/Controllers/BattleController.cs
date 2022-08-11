using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BattleController : MonoSingleton<BattleController>
{
    [Header("Turns Data")]
    [Space]
    [SerializeField] private int currentTurnNumber = 1;
    [Header("Delays")]
    [Space]
    [SerializeField] private float characterTurnDelay = 1f;

    private bool playerTurn = true;

    #region Events Methods
    public event Action<float> OnPlayerAttackFinished;
    public event Action<float> OnEnemyAttackFinished;
    public event Action OnEnemyTurnStart;
    public event Action OnPlayerTurnStart;
    public event Action OnPlayerOutOfHP;
    public event Action OnEnemyOutOfHP; 

    public void PlayerAttackFinishedCommand(float damage)
    {
        OnPlayerAttackFinished?.Invoke(damage);
        StartCoroutine(StartEnemyTurnCoroutine());
    }

    public void EnemyAttackFinishedCommand(float damage)
    {
        OnEnemyAttackFinished?.Invoke(damage);
        StartCoroutine(StartPlayerTurnCoroutine());
    }

    private void EnemyTurnStartCommand()
    {
        OnEnemyTurnStart?.Invoke();
    }

    private void PlayerTurnStartCommand()
    {
        OnPlayerTurnStart?.Invoke();
    }

    public void PlayerOutOfHPCommand()
    {
        OnPlayerOutOfHP?.Invoke();
    }

    public void EnemyOutOfHPCommad()
    {
        OnEnemyOutOfHP?.Invoke();
    }
    #endregion Events Methods

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

    public void SetEnemyTurn()
    {
        playerTurn = false;
    }

    #region Events Reaction Methods
    private void MainUI_CharacterChoosen_Reaction(Characters _)
    {
        playerTurn = true;
        BattleUI.Instance.UpdateTurnText(currentTurnNumber);
    }

    private void BattleUI_AttackButtonPressed_Reaction()
    {
        
    }

    private void BattleUI_GuardButtonPressed_Reaction()
    {
        
    }

    private void BattleUI_HealButtonPressed_Reaction()
    {
       
    }
    #endregion Events Reaction Methods

    private IEnumerator StartEnemyTurnCoroutine()
    {
        yield return new WaitForSeconds(characterTurnDelay);
        EnemyTurnStartCommand();
    }

    private IEnumerator StartPlayerTurnCoroutine()
    {
        yield return new WaitForSeconds(characterTurnDelay);
        PlayerTurnStartCommand();
    }
}
