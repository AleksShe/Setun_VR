using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.Controls.AxisControl;

[AosSdk.Core.Utils.AosObject(name: "Зеленая лампочка")]
public class TempAOSObject : SceneAosObject
{

    [AosAction(name: "")]
    public void SetText()
    {
    }

    [AosAction(name: "")]
    public void ResetText2()
    {
        Debug.Log("Text2");
    }
}