using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerCombatManager : CombatManager
{
    private bool guardActive = false;

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

        if(DoubleDamageActive())
        {
            currentDamage = DamageAmount * Multiplyers.DamageMultiplyer;
            BattleUI.Instance.ShowCriticalDamageText(true);
        }
        else
        {
            currentDamage = DamageAmount;
        }

        return currentDamage;
    }

    public void TakeDamage(float damage)
    {
        if(!guardActive)
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
        else
        {
            BattleUI.Instance.ShowBlockedText(true);
            guardActive = false;
        }
    }

    public void GuardActivation()
    {
        guardActive = true;
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
}
