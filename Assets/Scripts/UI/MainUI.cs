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

    #region Events Declaration
    public event Action OnStartGameButtonPressed;
    public event Action<Characters> OnCharacterChoosen; 

    public void StartGameButtonPressedCommand()
    {
        OnStartGameButtonPressed?.Invoke();
    }

    public void CharacterChoosenCommand(Characters character)
    {
        OnCharacterChoosen?.Invoke(character);
    }
    #endregion Events Declaration

    private void Start()
    {
        OnStartGameButtonPressed += StartButtonPressed_Reaction;
        OnCharacterChoosen += CharacterChoosen_Reaction;
    }

    private void OnDestroy()
    {
        OnStartGameButtonPressed -= StartButtonPressed_Reaction;
        OnCharacterChoosen -= CharacterChoosen_Reaction;
    }

    private void StartButtonPressed_Reaction()
    {
        mainMenuUI.HideMenu();
        characteristicsUI.ShowMenu();
    }

    private void CharacterChoosen_Reaction(Characters character)
    {
        characteristicsUI.HideMenu();
        BattleUI.Instance.ShowMenu();
    }
}
