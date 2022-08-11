using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class BattleUI : MonoSingleton<BattleUI>
{
    [Header("References")]
    [Space]
    [SerializeField] private List<Button> battleButtonsList = new List<Button>();
    [SerializeField] private TextMeshProUGUI turnText;

    private const string TurnString = "Turn ";

    private Transform content;

    #region Events Declaration
    public event Action OnAttackButtonPressed;
    public event Action OnGuardButtonPressed;
    public event Action OnHealButtonPressed;

    private void AttackButtonPressedCommand()
    {
        OnAttackButtonPressed?.Invoke();
    }

    private void GuardButtonPressedCommand()
    {
        OnGuardButtonPressed?.Invoke();
    }

    private void HealButtonPressedCommand()
    {
        OnHealButtonPressed?.Invoke();
    }
    #endregion Events Declaration

    private void Start()
    {
        CashComponents();
        SetContentActivationState(false);
    }

    public void ShowMenu()
    {
        SetContentActivationState(true);
    }    

    public void HideMenu()
    {
        SetContentActivationState(false);
    }

    public void UpdateTurnText(int turnNumber)
    {
        turnText.text = $"{TurnString} {turnNumber}";
    }

    #region Buttons Methods
    public void AttackButtonPressed()
    {
        SetButtonsActivationState(false);
        AttackButtonPressedCommand();
    }

    public void GuardButtonPressed()
    {
        SetButtonsActivationState(false);
        GuardButtonPressedCommand();
    }

    public void HealButtonPressed()
    {
        SetButtonsActivationState(false);
        HealButtonPressedCommand();
    }

    public void SetButtonsActivationState(bool isActive)
    {
        for(int i = 0; i < battleButtonsList.Count; i++)
        {
            battleButtonsList[i].interactable = isActive;
        }
    }
    #endregion Buttons Methods

    private void CashComponents()
    {
        content = transform.GetChild(0);
    }

    private void SetContentActivationState(bool isActive)
    {
        content.gameObject.SetActive(isActive);
    }
}
