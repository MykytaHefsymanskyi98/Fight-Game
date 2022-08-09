using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameButton : MonoBehaviour
{
    private bool buttonPressed = false;

    public void StartButtonPressed()
    {
        if(!buttonPressed)
        {
            buttonPressed = true;
            MainUI.Instance.StartGameButtonPressedCommand();
        }
    }
}
