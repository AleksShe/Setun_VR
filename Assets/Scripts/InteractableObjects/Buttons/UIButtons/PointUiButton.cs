using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
        Debug.Log(id);
    }
    public override void OnPointerEnter(PointerEventData eventData)
    {
        return;
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
        return;
    }
}
