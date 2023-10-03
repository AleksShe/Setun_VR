using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseUIButton : MonoBehaviour
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
}
