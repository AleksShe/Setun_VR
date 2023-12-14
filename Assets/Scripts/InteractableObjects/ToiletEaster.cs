using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletEaster : SceneObject
{
    [SerializeField] private Teleporter _teleportet;
    [SerializeField] private bool _toilet;

    public override void OnClicked(InteractHand interactHand)
    {
       if(_toilet)
            _teleportet.TeleportToToilet();
       else
            _teleportet.TeleportFromToilet();
    }
}
