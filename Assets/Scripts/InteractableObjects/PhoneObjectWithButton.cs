using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhoneObjectWithButton : ObjectWithButton
{
    public UnityAction ClickPhoneObjectEvent;
    [SerializeField] private BackButton _backButton;
    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        InstanceHandler.Instance.BackButtonsActivator.EnableCurrentBackButton(false);
        InstanceHandler.Instance.BackButtonsActivator.SetCurrentBackButton(_backButton);
        InstanceHandler.Instance.BackButtonsActivator.EnableCurrentBackButton(true);
        ClickPhoneObjectEvent.Invoke();
    }
}
