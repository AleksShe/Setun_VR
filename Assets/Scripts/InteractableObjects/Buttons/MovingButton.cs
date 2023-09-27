using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovingButton : BaseButton
{
    [SerializeField] protected string actionText;
    public override void OnHoverIn(InteractHand interactHand)
    {
        transform.localScale *= 1.5f;
        if (HelperPos == null)
            return;
        InstanceHandler.Instance.ObjectsInfoWindow.SetPosition(HelperPos);
        InstanceHandler.Instance.ObjectsInfoWindow.ShowWindowWithText(actionText);
    }
    public override void OnHoverOut(InteractHand interactHand)
    {
        transform.localScale /= 1.5f;
        if (HelperPos == null)
            return;
        InstanceHandler.Instance.ObjectsInfoWindow.HidetextHelper();
    }
    public void SetActionText(string text) => actionText = text;
}
