using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyCombatManager : CombatManager
{
    [Header("Character")]
    [Space]
    [SerializeField] private Characters character = Characters.Monster;

    #region Events Methods
    public event Action OnDamageTaken;
    public event Action OnAttackAction;

    private void DamageTakenCommand()
    {
        OnDamageTaken?.Invoke();
    }

    private void AttackActionCommand()
    {
        OnAttackAction?.Invoke();
    }
        #endregion Events Methods

    private void OnEnable()
    {
        SetCharacterCombatData(character);
    }

    public void TakeDamage(float damage)
    {
        CurrentHealthAmount -= damage;
        if(CurrentHealthAmount > 0)
        {
            DamageTakenCommand();
        }
        else
        {
            BattleController.Instance.EnemyOutOfHPCommad();
        }
    }

    public void ChooseCombatAction()
    {
        AttackActionCommand();
    }

    public float GetDamageDealt()
    {
        float damageAtAttack = DamageAmount;

        return damageAtAttack;
    }
}
