using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class BaseUIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    protected Button Button;
    public Action<bool> HoverUiEvent;
    public Action ClickButtonEvent;
    protected virtual void Awake()
    {
        Button = GetComponent<Button>();
        if (Button != null)
            Button.onClick.AddListener(() => Click());
    }
    protected virtual void Start()
    {
        InstanceHandler.Instance.AOSColliderActivator.AddBaseUIButton(this);
    }

    protected virtual void Click()
    {
        ClickButtonEvent?.Invoke();
    }
    public virtual void EnableUIButton(bool value)
    {
        if(Button!=null)
        Button.enabled = value;
    }
    public virtual void OnPointerExit(PointerEventData eventData)
    {
        HoverUiEvent?.Invoke(false);
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        HoverUiEvent?.Invoke(true);
    }
}
