using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWithButton : SceneObject
{
    [SerializeField] protected Transform _buttonsPos;

    protected DisabableObject DisabableObject;

    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        InstanceHandler.Instance.MovingButtonsController.HideAllButtons();
        if (_buttonsPos == null)
            return;
        InstanceHandler.Instance.MovingButtonsController.SetCurrentBaseObjectAndMovingButtonsPosition(_buttonsPos.position, this);
        InstanceHandler.Instance.MovingButtonsController.ObjectHelperName = HelperName;
        InstanceHandler.Instance.ReactionInfoWindow.HidetextHelper();
        InstanceHandler.Instance.MovingButtonsController.HandObject = null;
        InstanceHandler.Instance.SceneAosObject = SceneAOSObject;
        DisabableObject = GetComponent<DisabableObject>();
        if (DisabableObject != null)
            InstanceHandler.Instance.MovingButtonsController.HandObject = DisabableObject;
    }
}
