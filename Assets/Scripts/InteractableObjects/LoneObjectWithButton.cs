using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoneObjectWithButton : ObjectWithButton
{
    [SerializeField] private Transform _reactionPos;
    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        InstanceHandler.Instance.ReactionInfoWindow.SetPosition(_reactionPos);
    }
}
