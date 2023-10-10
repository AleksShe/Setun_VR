using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtkazAOSUIButton : BaseUIButton
{
    [SerializeField] private string _buttonId;
    protected override void Click() => InstanceHandler.Instance.API.OnReasonInvoke(_buttonId);
}
