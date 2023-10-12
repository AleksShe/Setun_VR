using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseArmUiButton :ArmButtonWithImage
{
    public delegate void CloseArmUiButtonClick(bool value);
    public event CloseArmUiButtonClick CloseUiButtonClickEvent;
    protected override void Click() => CloseUiButtonClickEvent?.Invoke(false);
}
