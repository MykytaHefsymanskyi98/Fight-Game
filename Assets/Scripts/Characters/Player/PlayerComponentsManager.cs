using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponentsManager : MonoBehaviour
{
    [Header("References")]
    [Space]
    [SerializeField] private PlayerModelsHolder modelsHolder;

    private PlayerAnimationManager animationManager;
    private PlayerCombatManager combatManager;

    private void Awake()
    {
        combatManager = GetComponent<PlayerCombatManager>();
    }

    private void Start()
    {
        MainUI.Instance.OnCharacterChoosen += MainUI_CharacterChoosen_Reaction;

        BattleUI.Instance.OnAttackButtonPressed += BattleUI_AttackButtonPressed_Reaction;
        BattleUI.Instance.OnGuardButtonPressed += BattleUI_GuardButtonPressed_Reaction;
        BattleUI.Instance.OnHealButtonPressed += BattleUI_HealButtonPressed_Reaction;

        BattleController.Instance.OnEnemyAttackFinished += BattleController_EnemyAttackFinished_Reaction;

        combatManager.OnDamageTaken += CombatManager_DamageTaken_Reaction;
        BattleController.Instance.OnPlayerOutOfHP += CombatManager_OutOfHP_Reaction;
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
        if(BattleController.Instance)
        {
            BattleController.Instance.OnEnemyAttackFinished -= BattleController_EnemyAttackFinished_Reaction;
            BattleController.Instance.OnPlayerOutOfHP -= CombatManager_OutOfHP_Reaction;
        }

        animationManager.OnAttackFinished -= AnimationManager_AttackFinished_Reaction;

        combatManager.OnDamageTaken -= CombatManager_DamageTaken_Reaction;
    }

    private void MainUI_CharacterChoosen_Reaction(Characters character)
    {
        modelsHolder.SetCharacterModel(character);
        animationManager = modelsHolder.CurrentModel.GetComponent<PlayerAnimationManager>();
        combatManager.SetCharacterCombatData(character);

        animationManager.OnAttackFinished += AnimationManager_AttackFinished_Reaction;
    }

    private void BattleUI_AttackButtonPressed_Reaction()
    {
        animationManager.SetAttackState();
    }

    private void BattleUI_GuardButtonPressed_Reaction()
    {
        animationManager.SetGuardState();
        combatManager.GuardActivation();
        BattleUI.Instance.ShowGuardText(true);
        BattleController.Instance.PlayerUsedGuardCommand();
    }

    private void BattleUI_HealButtonPressed_Reaction()
    {
        animationManager.SetHealState();
        combatManager.Heal();
    }

    private void BattleController_EnemyAttackFinished_Reaction(float damage)
    {
        combatManager.TakeDamage(damage);
    }

    private void AnimationManager_AttackFinished_Reaction()
    {
        float damageAtAttack = combatManager.GetDamageDealt();
        BattleController.Instance.PlayerAttackFinishedCommand(damageAtAttack);
    }

    private void CombatManager_DamageTaken_Reaction()
    {
        animationManager.SetHurtState();
    }

    private void CombatManager_OutOfHP_Reaction()
    {
        gameObject.SetActive(false);
    }
}
