using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWithButton : SceneObject
{
    [SerializeField] private Transform _buttonsPos;

    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        InstanceHandler.Instance.MovingButtonsController.HideAllButtons();
        if (_buttonsPos == null)
            return;
        InstanceHandler.Instance.MovingButtonsController.SetCurrentBaseObjectAndMovingButtonsPosition(_buttonsPos.position, this);
        InstanceHandler.Instance.MovingButtonsController.ObjectHelperName = HelperName;
    }
}
