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
    public Action<EnableScreen> EnableScreenEvent;
    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        EnableScreenEvent?.Invoke(_currentScreen);
        Debug.Log(_currentScreen.ToString());
    }
}
