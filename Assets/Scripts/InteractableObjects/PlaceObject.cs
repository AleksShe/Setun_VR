using AosSdk.Core.PlayerModule.Pointer;
using System;
using UnityEngine;

public class PlaceObject : SceneObject
{
    [SerializeField] private Camera _camera;
    [SerializeField] private string _backLocationName;

    private BaseSideMovingObject _sideMovingObject;
    private ObjectWithAnimation _objectWithAnimation;

    public Action<BaseSideMovingObject> SetSideMovingObjectEvent;
    public Action<Camera> CameraChangedEvent;
    public Action<string> SetBackLocationNameEvent;
    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        EnableHighlight(false);
        InvokePlaceEvents();
    }
    private void InvokePlaceEvents()
    {
        _objectWithAnimation = GetComponent<ObjectWithAnimation>();
        if (_objectWithAnimation != null)
        {
            _objectWithAnimation.PlayScriptableAnimationOpen();
            AddAnimationObjectEvent?.Invoke(_objectWithAnimation);
        }
        SetBackLocationNameEvent?.Invoke(_backLocationName);
        _sideMovingObject = GetComponent<BaseSideMovingObject>();
        if (_sideMovingObject != null)
            SetSideMovingObjectEvent?.Invoke(_sideMovingObject);
        if (_camera == null)
            return;
        CameraChangedEvent?.Invoke(_camera);
    }
}
