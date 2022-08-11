using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyComponentsManager : MonoBehaviour
{
    [Header("References")]
    [Space]
    [SerializeField] private EnemyAnimationManager animationManager;

    private EnemyCombatManager combatManager;

    private void OnEnable()
    {
        combatManager = GetComponent<EnemyCombatManager>();
    }

    private void Start()
    {
        BattleController.Instance.OnPlayerAttackFinished += BattleController_PlayerFinishedAttack_Reaction;
        BattleController.Instance.OnEnemyTurnStart += BattleController_StartEnemyTurn_Reaction;

        combatManager.OnDamageTaken += CombatManager_DamageTaken_Reaction;
        BattleController.Instance.OnEnemyOutOfHP += CombatManager_OutOfHP_Reaction;
        combatManager.OnAttackAction += CombatManager_AttackAction_Reaction;

        animationManager.OnAttackFinished += AnimationManager_AttackFinished_Reaction;
    }

    private void OnDestroy()
    {
        if(BattleController.Instance)
        {
            BattleController.Instance.OnPlayerAttackFinished -= BattleController_PlayerFinishedAttack_Reaction;
            BattleController.Instance.OnEnemyTurnStart -= BattleController_StartEnemyTurn_Reaction;
            BattleController.Instance.OnEnemyOutOfHP -= CombatManager_OutOfHP_Reaction;
        }

        combatManager.OnDamageTaken -= CombatManager_DamageTaken_Reaction;
        combatManager.OnAttackAction -= CombatManager_AttackAction_Reaction;

        animationManager.OnAttackFinished -= AnimationManager_AttackFinished_Reaction;
    }

    private void BattleController_PlayerFinishedAttack_Reaction(float damage)
    {
        combatManager.TakeDamage(damage);
    }

    private void BattleController_StartEnemyTurn_Reaction()
    {
        combatManager.ChooseCombatAction();
    }

    private void CombatManager_DamageTaken_Reaction()
    {
        animationManager.SetHurtState();
    }

    private void CombatManager_OutOfHP_Reaction()
    {
        gameObject.SetActive(false);
    }

    private void CombatManager_AttackAction_Reaction()
    {
        animationManager.SetAttackState();
    }

    private void AnimationManager_AttackFinished_Reaction()
    {
        BattleController.Instance.EnemyAttackFinishedCommand(combatManager.GetDamageDealt());
    }
}
