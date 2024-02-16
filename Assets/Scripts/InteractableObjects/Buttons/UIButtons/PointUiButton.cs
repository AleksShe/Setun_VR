using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointUiButton : BaseUIButton
{
    private string _pointId;
    public Action<string> PointClickEvent;
    protected override void Click()
    {
        PointClickEvent?.Invoke(_pointId);
    }
    public void SetButtonId(string id)
    {
        _pointId = id;
    }
}
