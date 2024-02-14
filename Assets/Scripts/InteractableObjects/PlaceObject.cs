using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObject : SceneObject
{
    [SerializeField] private Camera _camera;
    [SerializeField] private BackButton _backButton;
    [SerializeField] private Transform _reactionPos;
    [SerializeField] private Renderer[] _renderers;
    [SerializeField] private Color _color;
    private BaseSideMovingObject _sideMovingObject;
    private ObjectWithAnimation _objectWithAnimation;
    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        if (_backButton != null)
            InstanceHandler.Instance.BackButtonsActivator.SetCurrentBackButton(_backButton);
        if(_reactionPos!=null)
            InstanceHandler.Instance.HelpTextController.SetReactionPosition(_reactionPos);
        _objectWithAnimation = GetComponent<ObjectWithAnimation>();
        if (_objectWithAnimation != null)
        {
            _objectWithAnimation.PlayScriptableAnimationOpen();
            InstanceHandler.Instance.AddAnimationObjectToList(_objectWithAnimation);
        }
        if (_camera != null)
        {
            InstanceHandler.Instance.CanvasParentChanger.ChangeCameraParent(_camera);
            InstanceHandler.Instance.MouseRayCastHandler.CanHover = true;
            InstanceHandler.Instance.MouseRayCastHandler.CanInteract = true;
        }
        _sideMovingObject = GetComponent<BaseSideMovingObject>();
        if (_sideMovingObject != null)
            InstanceHandler.Instance.MoveUiButtonsHolder.SetSideMovingObject(_sideMovingObject);

        InstanceHandler.Instance.BackTriggersHolder.EnableCurrentTrigger(true);
    }
    public override void OnHoverIn(InteractHand interactHand)
    {
        if (_renderers == null || _renderers.Length < 1)
            base.OnHoverIn(interactHand);
        else
            HighlightMaterials(true);
    }
    public override void OnHoverOut(InteractHand interactHand)
    {
        if (_renderers == null || _renderers.Length < 1)
            base.OnHoverOut(interactHand);
        else
            HighlightMaterials(false);
    }

    private void HighlightMaterials(bool value)
    {
        foreach (var renderer in _renderers)
        {
            if (value)
            {
                renderer.material.color *= 2.5f;
                renderer.material.color = Color.white;
            }
            else
            {
                renderer.material.color /= 2.5f;
                renderer.material.color = _color;
            }
        }
    }
}
