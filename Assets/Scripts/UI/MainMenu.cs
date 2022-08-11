using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : UICanvas
{
    private void Awake()
    {
        CashComponents();
    }

    private void Start()
    {
        SetContentActivationState(true);
    }
}
