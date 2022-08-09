using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvas : MonoBehaviour
{
    private Transform content;

    public void CashComponents()
    {
        content = transform.GetChild(0);
    }

    public void SetContentActivationState(bool isActive)
    {
        content.gameObject.SetActive(isActive);
    }

    public void HideMenu()
    {
        SetContentActivationState(false);
    }

    public void ShowMenu()
    {
        SetContentActivationState(true);
    }
}
