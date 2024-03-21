using AosSdk.Core.PlayerModule;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class NextUIButton : BaseUIButton, INextButton
{
    public NextButtonState CurrentState { get; set; }
    [SerializeField] private GameObject _guideButton;
    public event NextButtonPressed NextButtonPressedEvent;


    protected override void Click()
    {
        ClickNextButton();
    }
    public void ClickNextButton()
    {
        if (CurrentState == NextButtonState.Start)
        {
            NextButtonPressedEvent?.Invoke("next");
            if (_guideButton != null)
            {
                _guideButton.SetActive(false);
            }
        }

        else if (CurrentState == NextButtonState.Fault)
            NextButtonPressedEvent?.Invoke("start");
    }
}
