using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Image))]
public class ArmButtonWithImage : BaseUIButton
{
    protected Image Image;
    protected override void Awake()
    {
        base.Awake();
        Image = GetComponent<Image>();
    }
    public override void EnableUIButton(bool value)
    {
        base.EnableUIButton(value);
        if(Image!=null)
        Image.enabled = value;
    }
}
