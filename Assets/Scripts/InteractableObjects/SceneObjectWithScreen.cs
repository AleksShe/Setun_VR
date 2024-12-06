using AosSdk.Core.PlayerModule.Pointer;
using System;
using UnityEngine;
public enum EnableScreen
{
    Phone,
    ARM
}

public class SceneObjectWithScreen : SceneObject
{
    [SerializeField] private EnableScreen _currentScreen;
    [SerializeField] private string _backLocationName;
    public Action<string> SetBackLocationNameEventSc;
    public Action<EnableScreen> EnableScreenEvent;
    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        EnableScreenEvent?.Invoke(_currentScreen);
        if(_backLocationName != null)
        SetBackLocationNameEventSc?.Invoke(_backLocationName);

    }
}
