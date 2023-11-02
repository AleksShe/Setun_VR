using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiresObject : ToolObject
{
    [SerializeField] private Animator _wires;

    private const string WIRE_ANIMATON = "Tool";
    private bool _canAnim = true;
    public override void PlayToolAnimation()
    {
        if (_wires == null || !_canAnim)
            return;
            _wires.SetTrigger(WIRE_ANIMATON);
            _canAnim = false;
    }
}
