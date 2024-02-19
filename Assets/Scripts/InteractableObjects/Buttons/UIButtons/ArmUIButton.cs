using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(SceneAosObject))]
public class ArmUIButton : ArmButtonWithImage
{
    private SceneAosObject _sceneObject;
    protected override void Awake()
    {
        base.Awake();
        _sceneObject = GetComponent<SceneAosObject>();
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
