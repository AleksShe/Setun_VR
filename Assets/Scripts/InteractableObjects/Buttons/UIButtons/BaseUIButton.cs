using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseUIButton : MonoBehaviour
{
    protected Button Button;
    protected virtual void Awake()
    {
        Button = GetComponent<Button>();
        Button.onClick.AddListener(() => Click());
    }

    protected virtual void Click()
    {
    }
    public virtual void EnableUIButton(bool value)
    {
        Button.enabled = value;
    }
}
