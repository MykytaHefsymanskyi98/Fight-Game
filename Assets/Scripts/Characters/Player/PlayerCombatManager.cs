using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCombatManager : CombatManager
{
    #region Events Methods
    public event Action OnDamageTaken;

    private void DamageTakenCommand()
    {
        OnDamageTaken?.Invoke();
    }
    #endregion Events Methods

    public float GetDamageDealt()
    {
        float currentDamage = 0f;
        currentDamage = DamageAmount;

        return currentDamage;
    }

    public void TakeDamage(float damage)
    {
        CurrentHealthAmount -= damage;
        if (CurrentHealthAmount > 0)
        {
            DamageTakenCommand();
            float changedValue = CurrentHealthAmount.Remap(0, StartHealthAmount, 0, 1f);
            BattleUI.Instance.UpdatePlayerHealthBar(changedValue);
        }
        else
        {
            BattleController.Instance.PlayerOutOfHPCommand();
            BattleUI.Instance.UpdatePlayerHealthBar(0f);
        }
    }
}
