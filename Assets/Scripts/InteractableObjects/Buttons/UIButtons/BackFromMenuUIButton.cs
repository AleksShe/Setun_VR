using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackFromMenuUIButton : BaseUIButton
{
    public delegate void BackButtonClick();
    public static event BackButtonClick BackButtonClickEvent;
    protected override void Click()
    {
        Debug.Log("Click from back button");
     BackButtonClickEvent?.Invoke();
    }
}