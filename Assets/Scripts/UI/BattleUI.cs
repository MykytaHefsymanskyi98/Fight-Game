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

    public void CashComponents()
    {
        content = transform.GetChild(0);
    }

    public void SetContentActivationState(bool isActive)
    {
        content.gameObject.SetActive(isActive);
    }
}
