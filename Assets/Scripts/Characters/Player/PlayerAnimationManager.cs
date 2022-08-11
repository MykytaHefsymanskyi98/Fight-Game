using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAnimationManager : MonoBehaviour
{
    private Animator animator;

    #region Events Methods
    public event Action OnAttackFinished;

    public void AttackFinishedCommand()
    {
        OnAttackFinished?.Invoke();
    }
    #endregion Events Methods

    private void OnEnable()
    {
        animator = GetComponent<Animator>();
    }

    public void SetAttackState()
    {
        animator.SetTrigger(Animations.Attack);
    }

    public void SetGuardState()
    {
        animator.SetTrigger(Animations.Block);
    }

    public void SetHealState()
    {
        animator.SetTrigger(Animations.Block);
    }

    public void SetHurtState()
    {
        animator.SetTrigger(Animations.Hurt);
    }

    public void SetLoseState()
    {
        animator.SetTrigger(Animations.Lose);
    }
}
