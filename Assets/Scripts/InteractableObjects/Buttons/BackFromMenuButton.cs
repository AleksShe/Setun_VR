using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackFromMenuButton : BaseButton
{

    public override void OnClicked(InteractHand interactHand)
    {
        InstanceHandler.Instance.Teleporter.TeleportToMenu();
    }
}
