using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : MonoSingleton<LevelManager>
{
    private bool gameOver = false;
        
    public bool GameOver { get => gameOver; set => gameOver = value; }

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
        gameOver = true;
    }

    private void PlayerLose()
    {
        gameOver = true;
    }
}
