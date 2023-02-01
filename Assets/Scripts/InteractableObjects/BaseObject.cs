using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseObject : MonoBehaviour, IClickAble, IHoverAble
{
    public bool IsHoverable { get; set; } = true;
    public bool IsClickable { get; set; } = true;

    protected SceneAosObject SceneAOSObject;
    public virtual void OnClicked(InteractHand interactHand)
    {
        if (SceneAOSObject == null)
            return;
        SceneAOSObject.InvokeOnClick();
    }
    public virtual void OnHoverIn(InteractHand interactHand)
    {
    }
    public virtual void OnHoverOut(InteractHand interactHand)
    {
    }
    public virtual void EnableObject(bool value)
    {
    }

}
