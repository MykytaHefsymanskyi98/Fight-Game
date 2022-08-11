using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    private Animator animator;

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
}
