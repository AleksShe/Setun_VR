using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonWithTextEvent : BaseUIButton
{
    [SerializeField] private string _text;
    protected override void Click()
    {
       var API = FindObjectOfType<API>();
        if(API != null )
            API.OnInvokeNavAction(_text);
    }
}
