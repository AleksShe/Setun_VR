using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(SceneAosObject))]
public class ArmUIButton : ArmButtonWithImage
{
    private SceneAosObject _sceneObject;
    private CloseArmUiButton _closeButton;
    protected override void Awake()
    {
        base.Awake();
        _sceneObject = GetComponent<SceneAosObject>();
        _closeButton = GetComponentInChildren<CloseArmUiButton>();
    }
    private void Start()
    {
        if(_closeButton!=null)
        _closeButton.CloseUiButtonClickEvent += EnableUIButton;
        //InstanceHandler.Instance.AOSColliderActivator.AddArmIUObject(this);
    }
    public override void EnableUIButton(bool value)
    {
        base.EnableUIButton(value);
        if (_closeButton != null)
            _closeButton.EnableUIButton(value);
    }
    protected override void Click()
    {
        if (_sceneObject == null)
            return;
        _sceneObject.InvokePointAction();
    }
    public string GetAOSName()
    {
        return _sceneObject == null ? null : _sceneObject.ObjectId;
    }
    public void SetSceneAosEventText(string actionText)
    {
        _sceneObject.SetPointActionText(actionText);
    }
}
