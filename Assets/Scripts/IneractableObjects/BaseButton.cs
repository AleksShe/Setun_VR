using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseButton : BaseObject
{
    public override void OnHoverIn(InteractHand interactHand)
    {
        transform.localScale *= 1.2f;

    }
    public override void OnHoverOut(InteractHand interactHand)
    {
        transform.localScale /= 1.2f;
    }
}
