using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BackFromDialogButton : BaseButton
{
    public UnityAction OnCkickBackDialog;
    public override void OnClicked(InteractHand interactHand)
    {
        OnCkickBackDialog?.Invoke();
        InstanceHandler.Instance.BackButtonsActivator.EnableCurrentBackButton(true);
    }
}
