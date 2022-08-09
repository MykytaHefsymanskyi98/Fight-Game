using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainUI : MonoSingleton<MainUI>
{
    [Header("UI Canvases")]
    [Space]
    [SerializeField] private MainMenu mainMenuUI;
    [SerializeField] private CharacteristicsUI characteristicsUI;
    [SerializeField] private BattleUI battleUI;

    #region Events Declaration
    public event Action OnStartGameButtonPressed;

    public void StartGameButtonPressedCommand()
    {
        OnStartGameButtonPressed?.Invoke();
    }
    #endregion Events Declaration

    private void Start()
    {
        OnStartGameButtonPressed += StartButton_ButtonPressed_Reaction;
    }

    private void OnDestroy()
    {
        OnStartGameButtonPressed -= StartButton_ButtonPressed_Reaction;
    }

    private void StartButton_ButtonPressed_Reaction()
    {
        mainMenuUI.HideMenu();
        characteristicsUI.ShowMenu();
    }
}
