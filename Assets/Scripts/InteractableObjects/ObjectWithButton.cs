using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWithButton : SceneObject
{
    [SerializeField] protected Transform _buttonsPos;

    private ObjectWithAnimation _objectWithAnimation;
    private ToolObject _toolObject;

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
        _objectWithAnimation = GetComponent<ObjectWithAnimation>();
        if (_objectWithAnimation != null)
        {
            _objectWithAnimation.PlayScriptableAnimationOpen();
            InstanceHandler.Instance.AddAnimationObjectToList(_objectWithAnimation);
        }
        _toolObject = GetComponent<ToolObject>();
        if (_toolObject != null)
            InstanceHandler.Instance.MovingButtonsController.ToolObject = _toolObject;
        else
            InstanceHandler.Instance.MovingButtonsController.ToolObject = null;
    }

}
