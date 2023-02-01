using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AmperLidButton : BaseButton
{
    [SerializeField] private bool _side;
    public UnityAction <bool> RotateButton;
    public override void OnClicked(InteractHand interactHand)
    {
        RotateButton?.Invoke(_side);
    }
}
