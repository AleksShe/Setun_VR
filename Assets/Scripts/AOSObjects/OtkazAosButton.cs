using AosSdk.Core.PlayerModule.Pointer;
using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtkazAosButton :BaseButton
{

    public override void OnClicked(InteractHand interactHand)
    {
            API api = FindObjectOfType<API>();
            api.OnReasonInvoke(gameObject.name);
    }
}
