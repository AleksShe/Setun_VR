using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObjectUIButton : BaseUIButton
{
    [SerializeField] private ObjectEnabler _objEnabler;
    protected override void Click()
    {
        _objEnabler.EnableObject(true); 
    }
}
