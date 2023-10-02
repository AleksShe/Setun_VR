using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiresObject : ToolObject
{
    [SerializeField] private Animator _wires;

    private const string WIRE_ANIMATON = "Tool";
    public override void PlayToolAnimation()
    {
        if (_wires == null)
        {
            Debug.Log("No Wires");
            return;
        }
        _wires.SetTrigger(WIRE_ANIMATON);
    }
}
