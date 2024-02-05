using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackFromMenuUIButton : BaseUIButton
{
    public delegate void BackButtonClick();
    public static event BackButtonClick BackButtonClickEvent;
    [SerializeField] private bool _event;
    [SerializeField] private GameObject _messagePanel;
    protected override void Click()
    {
        if(_event)
        InstanceHandler.Instance.API.OnInvokeNavAction(InstanceHandler.Instance.BackButtonsActivator.ActionToInvoke);
        BackButtonClickEvent?.Invoke();
        if(_messagePanel != null)
        {
            _messagePanel.SetActive(false);
        }
        
    }
}
