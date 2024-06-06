using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIPhoneButton : UIMenuButton
{
    public Action<bool> PhoneBackButtonClickedEvent;
    public bool closeButton = false;
    protected override void Click()
    {
        base.Click();
       
        if (closeButton)
        {
            PhoneBackButtonClickedEvent?.Invoke(true);
            API.InvokeEndTween("shn_place");
        }
        else
            PhoneBackButtonClickedEvent?.Invoke(false);

    }
    public override void OnPointerEnter(PointerEventData eventData)
    {
        
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
        
    }
}
