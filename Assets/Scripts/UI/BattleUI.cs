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
    [SerializeField] private TextMeshProUGUI playerCombatText;
    [SerializeField] private TextMeshProUGUI enemyCombatText;
    [SerializeField] private TextMeshProUGUI battleResultText;
    [Header("Health Bars")]
    [Space]
    [SerializeField] private HealthBar playerHealthBar;
    [SerializeField] private HealthBar enemyHealthBar;
    [Header("Combat Texts")]
    [Space]
    [SerializeField] private string attackText = $"Attack";
    [SerializeField] private string guardText = $"Guard Activated";
    [SerializeField] private string blockedText = $"Blocked";
    [SerializeField] private string DamageDecreasedText = $"Damage Decreased";
    [SerializeField] private string healText = $"Heal";
    [SerializeField] private string CriticalDamageText = $"CriticalDamage";
    [SerializeField] private string AdditionalDeffenceText = $"AdditionalDeffence";
    [Space]
    [SerializeField] private string winText = $"You Win";
    [SerializeField] private string loseText = $"You Lose";
    [Header("Delays")]
    [Space]
    [SerializeField] private float hideCombatTextDelay = 1f;

    private const string TurnString = "Turn ";

    private Transform content;

    private Coroutine playerTextCoroutine;
    private Coroutine enemyTextCoroutine;

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
        BattleController.Instance.OnPlayerTurnStart += BattleController_PlayerTurn_Reaction;
        BattleController.Instance.OnPlayerOutOfHP += BattleController_PlayerOutOfHP_Reaction;
        BattleController.Instance.OnEnemyOutOfHP += BattleController_EnemyOutOfHP_Reaction;

        CashComponents();
        SetContentActivationState(false);

        SetStartParameters();
    }

    private void OnDestroy()
    {
        if(BattleController.Instance)
        {
            BattleController.Instance.OnPlayerTurnStart -= BattleController_PlayerTurn_Reaction;
            BattleController.Instance.OnPlayerOutOfHP -= BattleController_PlayerOutOfHP_Reaction;
            BattleController.Instance.OnEnemyOutOfHP -= BattleController_EnemyOutOfHP_Reaction;
        }
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

    public void UpdatePlayerHealthBar(float value)
    {
        playerHealthBar.UpdateHealthBar(value);
    }

    public void UpdateEnemyHealthBar(float value)
    {
        enemyHealthBar.UpdateHealthBar(value);
    }

    public void ShowCriticalDamageText(bool playerText)
    {
        if(playerText)
        {
            playerTextCoroutine = StartCoroutine(ShowCombatActionTextCoroutine(CriticalDamageText, playerCombatText));
        }
        else
        {
            enemyTextCoroutine = StartCoroutine(ShowCombatActionTextCoroutine(CriticalDamageText, enemyCombatText));
        }
    }

    public void ShowAdditionalDeffenceText(bool playerText)
    {
        if(playerText)
        {
            playerTextCoroutine = StartCoroutine(ShowCombatActionTextCoroutine(AdditionalDeffenceText, playerCombatText));
        }
        else
        {
            enemyTextCoroutine = StartCoroutine(ShowCombatActionTextCoroutine(AdditionalDeffenceText, enemyCombatText));
        }
    }

    public void ShowGuardText(bool playerText)
    {
        if (playerText)
        {
            playerTextCoroutine = StartCoroutine(ShowCombatActionTextCoroutine(guardText, playerCombatText));
        }
        else
        {
            enemyTextCoroutine = StartCoroutine(ShowCombatActionTextCoroutine(guardText, enemyCombatText));
        }
    }

    public void ShowBlockedText(bool playerText)
    {
        if (playerText)
        {
            playerTextCoroutine = StartCoroutine(ShowCombatActionTextCoroutine(blockedText, playerCombatText));
        }
        else
        {
            enemyTextCoroutine = StartCoroutine(ShowCombatActionTextCoroutine(blockedText, enemyCombatText));
        }
    }

    public void ShowDamageDecreasedText(bool playerText)
    {
        if (playerText)
        {
            playerTextCoroutine = StartCoroutine(ShowCombatActionTextCoroutine(DamageDecreasedText, playerCombatText));
        }
        else
        {
            enemyTextCoroutine = StartCoroutine(ShowCombatActionTextCoroutine(DamageDecreasedText, enemyCombatText));
        }
    }

    public void ShowHealText(bool playerText)
    {
        if (playerText)
        {
            playerTextCoroutine = StartCoroutine(ShowCombatActionTextCoroutine(healText, playerCombatText));
        }
        else
        {
            enemyTextCoroutine = StartCoroutine(ShowCombatActionTextCoroutine(healText, enemyCombatText));
        }
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

    private void SetStartParameters()
    {
        playerCombatText.text = $"";
        enemyCombatText.text = $"";
        battleResultText.text = $"";
    }

    private void SetContentActivationState(bool isActive)
    {
        content.gameObject.SetActive(isActive);
    }

    private void BattleController_PlayerTurn_Reaction()
    {
        SetButtonsActivationState(true);
    }

    private void BattleController_PlayerOutOfHP_Reaction()
    {
        battleResultText.text = loseText;
        SetButtonsActivationState(false);
    }

    private void BattleController_EnemyOutOfHP_Reaction()
    {
        battleResultText.text = winText;
        SetButtonsActivationState(false);
    }

    private IEnumerator ShowCombatActionTextCoroutine(string combatText, TextMeshProUGUI characterText)
    {
        characterText.text = combatText;
        yield return new WaitForSeconds(hideCombatTextDelay);
        characterText.text = $"";
    }
}
