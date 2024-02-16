using AosSdk.Core.PlayerModule;
using System.Diagnostics;
using UnityEngine.UI;

public class NextUIButton : BaseUIButton, INextButton
{
    public NextButtonState CurrentState { get; set; }

    public event NextButtonPressed NextButtonPressedEvent;

    protected override void Click()
    {
        ClickNextButton();
    }
    public void ClickNextButton()
    {
        if (CurrentState == NextButtonState.Start)
            NextButtonPressedEvent?.Invoke("next");
        else if (CurrentState == NextButtonState.Fault)
            NextButtonPressedEvent?.Invoke("start");
    }
}
