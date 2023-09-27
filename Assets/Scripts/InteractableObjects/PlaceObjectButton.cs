using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlaceObjectButton : PhoneObjectWithButton
{
    [SerializeField] private TextMeshProUGUI _buttonText;
    public override void OnHoverIn(InteractHand interactHand) => transform.localScale *= 1.2f;

    public override void OnHoverOut(InteractHand interactHand) => transform.localScale /= 1.2f;

    public override void SetHelperName(string value) => _buttonText.text = value;

    public override void EnableObject(bool value)
    {
        base.EnableObject(value);
        _buttonText.enabled = value;
    }
}
