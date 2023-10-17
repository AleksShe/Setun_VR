using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
[AosSdk.Core.Utils.AosObject(name: "AosObject")]
public class SceneAosObject : AosObjectBase
{
    [AosEvent(name: "OnClickObject")]
    public event AosEventHandlerWithAttribute OnClickObject;
    [AosEvent(name: "OnClickObject")]
    public event AosEventHandlerWithAttribute OnClickDialogObject;
    [AosEvent(name: "OnClickObject")]
    public event AosEventHandlerWithAttribute OnPointAction;
    private string _pointActionText;
    public void InvokeOnClick() => OnClickObject?.Invoke(ObjectId);
    public void InvokeOnClickDialog() => OnClickDialogObject?.Invoke(ObjectId);
    public void ActionWithObject(string actionName) => OnClickObject?.Invoke(actionName);
    public void InvokePointAction() => OnPointAction?.Invoke(_pointActionText);
    public void SetPointActionText(string text) => _pointActionText = text;
}
