using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUI : MonoSingleton<BattleUI>
{
    private Transform content;

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

    private void CashComponents()
    {
        content = transform.GetChild(0);
    }

    private void SetContentActivationState(bool isActive)
    {
        content.gameObject.SetActive(isActive);
    }
}
