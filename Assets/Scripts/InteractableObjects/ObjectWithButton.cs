using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWithButton : SceneObject
{
    [SerializeField] protected Transform _buttonsPos;

    protected ObjectWithAnimation ObjectWithAnimation;
    protected ToolObject ToolObject;

    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        InstanceHandler.Instance.MovingButtonsController.HideAllButtons();
        if (_buttonsPos == null)
            return;
        InstanceHandler.Instance.MovingButtonsController.SetCurrentBaseObjectAndMovingButtonsPosition(_buttonsPos.position, this);
        InstanceHandler.Instance.MovingButtonsController.ObjectHelperName = HelperName;
        InstanceHandler.Instance.HelpTextController.HideReactionText();
        InstanceHandler.Instance.MovingButtonsController.HandObject = null;
        InstanceHandler.Instance.SceneAosObject = SceneAOSObject;
        ObjectWithAnimation = GetComponent<ObjectWithAnimation>();
        if (ObjectWithAnimation != null)
        {
            ObjectWithAnimation.PlayScriptableAnimationOpen();
            InstanceHandler.Instance.AddAnimationObjectToList(ObjectWithAnimation);
        }
        ToolObject = GetComponent<ToolObject>();
        if (ToolObject != null)
            InstanceHandler.Instance.MovingButtonsController.ToolObject = ToolObject;
        else
            InstanceHandler.Instance.MovingButtonsController.ToolObject = null;
    }

}
