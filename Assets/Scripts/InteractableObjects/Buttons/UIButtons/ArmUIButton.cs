using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(SceneAosObject))]
public class ArmUIButton : ArmButtonWithImage
{
    private SceneAosObject _sceneObject;
    private string _name;
    protected override void Awake()
    {
        base.Awake();
        _sceneObject = GetComponent<SceneAosObject>();
    }
    protected override void Click()
    {
        SendArmButton();
    }
    public string GetAOSName()
    {
        return _sceneObject == null ? null : _sceneObject.ObjectId;
    }
    public void SetSceneAosEventText(string actionText,string name)
    {     
        _sceneObject.SetPointActionText(actionText);
        _name = name;
        Debug.Log("DATA "+name+actionText);
    }
    private void SendArmButton()
    {
        var jsonObject = new JsonAosObject();
        jsonObject.eventName = "OnPointAction";
        jsonObject.castedToStringAttribute = "OnClick";
        jsonObject.objectId = _name;
        WebSocketWrapper.Instance.DoSendMessage(jsonObject);
    }
}
