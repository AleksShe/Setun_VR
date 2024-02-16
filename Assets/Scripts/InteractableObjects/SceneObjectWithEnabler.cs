using AosSdk.Core.PlayerModule.Pointer;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EnableScreen
{
    Phone,
    ARM_1,
    ARM_2
}

public class SceneObjectWithEnabler : SceneObject
{
    [SerializeField] private EnableScreen _currentScreen;
    public Action<EnableScreen> EnableScreenEvent;
    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        EnableScreenEvent?.Invoke(_currentScreen);

    }
}
