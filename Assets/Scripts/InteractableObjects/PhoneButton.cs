using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PhoneButton : BaseButton
{
    [SerializeField] private TextMeshProUGUI _buttonText;


    public override void SetHelperName(string value)
    {
        _buttonText.text = value;
    }
    public override void EnableObject(bool value)
    {
        base.EnableObject(value);
        _buttonText.enabled = value;
    }
}
