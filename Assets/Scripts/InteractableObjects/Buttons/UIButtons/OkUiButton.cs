using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OkUiButton : BaseUIButton
{
    public Action OkClickEvent;
    protected override void Click()
    {
       OkClickEvent?.Invoke();
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
        return;
    }
}
