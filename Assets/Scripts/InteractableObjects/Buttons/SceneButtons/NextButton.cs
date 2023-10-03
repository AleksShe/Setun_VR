using AosSdk.Core.PlayerModule.Pointer;
using AosSdk.Core.PlayerModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NextButton : BaseButton
{
    public UnityAction<string> NextButtonPressedEvent;
    [HideInInspector] public NextButtonState CurrentState;
    public override void OnClicked(InteractHand interactHand)
    {
        if (CurrentState == NextButtonState.Start)
        {
           InstanceHandler.Instance.API.OnInvokeNavAction("next");
            NextButtonPressedEvent?.Invoke("next");
            Player.Instance.CanMove = false;
        }
        else if (CurrentState == NextButtonState.Fault)
        {
            InstanceHandler.Instance.API.OnInvokeNavAction("start");
            NextButtonPressedEvent?.Invoke("start");
            Player.Instance.CanMove = true;
        }
    }
}
