using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : MonoSingleton<LevelManager>
{
    private void Start()
    {
        BattleController.Instance.OnEnemyOutOfHP += PlayerWin;
        BattleController.Instance.OnPlayerOutOfHP += PlayerLose;
    }

    private void OnDestroy()
    {
        if(BattleController.Instance)
        {
            BattleController.Instance.OnEnemyOutOfHP -= PlayerWin;
            BattleController.Instance.OnPlayerOutOfHP -= PlayerLose;
        }
    }

    private void PlayerWin()
    {

    }

    private void PlayerLose()
    {

    }
}
