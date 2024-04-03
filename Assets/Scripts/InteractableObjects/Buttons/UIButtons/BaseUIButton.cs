using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class BaseUIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    protected Button Button;
    protected API API;
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
        API = FindObjectOfType<API>();
        SceneObjectsHolder.Instance.AddBaseUIButton(this);
    }

    protected virtual void Click() => ClickButtonEvent?.Invoke();
    public virtual void EnableUIButton(bool value)
    {
        if(Button!=null)
        Button.enabled = value;
    }
    public virtual void OnPointerExit(PointerEventData eventData) => HoverUiEvent?.Invoke(false);

    public virtual void OnPointerEnter(PointerEventData eventData) => HoverUiEvent?.Invoke(true);
}
