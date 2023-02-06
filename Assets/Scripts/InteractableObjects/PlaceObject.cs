using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObject : SceneObject
{
    [SerializeField] private BackButton _backButton;
    [SerializeField] private Transform _reactionPos;
    private ObjectWithAnimation _objectWithAnimation;
    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        if (_backButton != null)
            InstanceHandler.Instance.BackButtonsActivator.SetCurrentBackButton(_backButton);
        if(_reactionPos!=null)
            InstanceHandler.Instance.ReactionInfoWindow.SetPosition(_reactionPos);
        _objectWithAnimation = GetComponent<ObjectWithAnimation>();
        if (_objectWithAnimation != null)
        {
            _objectWithAnimation.PlayScriptableAnimation();
            InstanceHandler.Instance.PlaceAnimationObject = _objectWithAnimation;
        }
    }
}
