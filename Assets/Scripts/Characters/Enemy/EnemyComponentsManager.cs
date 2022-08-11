using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyComponentsManager : MonoBehaviour
{
    [Header("References")]
    [Space]
    [SerializeField] private EnemyAnimationManager animationManager;

    private void Start()
    {
        BattleController.Instance.OnPlayerAttackFinished += BattleController_PlayerFinishedAttack_Reaction;
    }

    private void OnDestroy()
    {
        if(BattleController.Instance)
        {
            BattleController.Instance.OnPlayerAttackFinished -= BattleController_PlayerFinishedAttack_Reaction;
        }
    }

    private void BattleController_PlayerFinishedAttack_Reaction(float damage)
    {

    }
}
