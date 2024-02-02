using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackFromMenuUIButton : BaseUIButton
{
    public delegate void BackButtonClick();
    public static event BackButtonClick BackButtonClickEvent;
    [SerializeField] private bool _event;
    protected override void Click()
    {
        if(_event)
        InstanceHandler.Instance.API.OnInvokeNavAction(InstanceHandler.Instance.BackButtonsActivator.ActionToInvoke);
        BackButtonClickEvent?.Invoke();
        
    }
}
