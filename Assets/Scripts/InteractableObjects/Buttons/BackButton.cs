using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;
public class BackButton : BaseButton
{
    public UnityAction BackButtonClickEvent;

    public override void OnClicked(InteractHand interactHand)
    {
        InstanceHandler.Instance.MovingButtonsController.HideAllButtons();
        API api = FindObjectOfType<API>();
        api.OnInvokeNavAction(InstanceHandler.Instance.BackButtonsActivator.ActionToInvoke);
        InstanceHandler.Instance.PlayCloseAnimationForAllObjects();
        InstanceHandler.Instance.BackButtonsActivator.SetCurrentBackButton(null);
        InstanceHandler.Instance.HelpTextController.HideReactionText();
        BackButtonClickEvent?.Invoke();
    }
}
