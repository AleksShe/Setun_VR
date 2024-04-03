using AosSdk.Core.PlayerModule;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class NextUIButton : BaseUIButton
{
    public delegate void NextButtonPressed(string name);

    public event NextButtonPressed NextButtonPressedEvent;

    protected override void Click()
    {
        ClickNextButton();
    }
    public void ClickNextButton()
    {
        API.OnInvokeNavAction("start");
        NextButtonPressedEvent?.Invoke("start");
    }
}
