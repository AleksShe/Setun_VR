using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPhoneButton : UIMenuButton
{
    public Action PhoneBackButtonClickedEvent;
    protected override void Click()
    {
        base.Click();
        PhoneBackButtonClickedEvent?.Invoke();
    }
}
