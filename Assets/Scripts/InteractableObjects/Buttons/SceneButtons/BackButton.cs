using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Rendering.DebugUI;

public class BackButton : BaseButton
{
    public UnityAction BackButtonClickEvent;

    public override void OnClicked(InteractHand interactHand)
    {
        InstanceHandler.Instance.MovingButtonsController.HideAllButtons();
        InstanceHandler.Instance.API.OnInvokeNavAction(InstanceHandler.Instance.BackButtonsActivator.ActionToInvoke);
        InstanceHandler.Instance.PlayCloseAnimationForAllObjects();
        InstanceHandler.Instance.BackButtonsActivator.SetCurrentBackButton(null);
        InstanceHandler.Instance.HelpTextController.HideReactionText();
        InstanceHandler.Instance.BackTriggersHolder.EnableCurrentTrigger(false);
        BackButtonClickEvent?.Invoke();
    }
}
