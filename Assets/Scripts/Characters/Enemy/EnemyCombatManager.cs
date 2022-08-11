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
        if (DecreasedDamageActive())
        {
            // Multiplyers.DamagedDecreasedMultiplyer - 80% of damage, Multiplyers.DamagedMaxMultiplyer - 100% damage: Decreased damage calculation
            damage = (damage * Multiplyers.DamagedDecreasedMultiplyer) / Multiplyers.DamagedMaxMultiplyer;
            BattleUI.Instance.ShowDamageDecreasedText(false);
        }

        CurrentHealthAmount -= damage;
        if(CurrentHealthAmount > 0)
        {
            DamageTakenCommand();
            float changedValue = CurrentHealthAmount.Remap(0, StartHealthAmount, 0, 1f);
            BattleUI.Instance.UpdateEnemyHealthBar(changedValue);
        }
        else
        {
            BattleController.Instance.EnemyOutOfHPCommad();
            BattleUI.Instance.UpdateEnemyHealthBar(0f);
        }
    }

    public void ChooseCombatAction()
    {
        AttackActionCommand();
    }

    public float GetDamageDealt()
    {
        float damageAtAttack;

        if (DoubleDamageActive())
        {
            damageAtAttack = DamageAmount * Multiplyers.DamageMultiplyer;
            BattleUI.Instance.ShowCriticalDamageText(false);
        }
        else
        {
            damageAtAttack = DamageAmount;
        }

        return damageAtAttack;
    }

    private bool DoubleDamageActive()
    {
        int tempValue = UnityEngine.Random.Range(0, Multiplyers.ChanceMultiplyer);

        if (tempValue * Multiplyers.ChanceMultiplyer <= DoubleDamageDealtChance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool DecreasedDamageActive()
    {
        int tempValue = UnityEngine.Random.Range(0, Multiplyers.ChanceMultiplyer);

        if (tempValue * Multiplyers.ChanceMultiplyer <= DecreaseDamageChance)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
