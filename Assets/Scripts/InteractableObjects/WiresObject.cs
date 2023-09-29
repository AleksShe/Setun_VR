using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiresObject : ToolObject
{
    [SerializeField] private Animator _wires;

    private const string WIRE_1_ANIMATON = "Wire1";
    private const string WIRE_2_ANIMATON = "Wire2";
    public override void PlayToolAnimation()
    {
        if (_wires == null)
        {
            Debug.Log("No Wires");
            return;
        }
        _wires.SetTrigger(WIRE_1_ANIMATON);
        _wires.SetTrigger(WIRE_2_ANIMATON);
    }
}
