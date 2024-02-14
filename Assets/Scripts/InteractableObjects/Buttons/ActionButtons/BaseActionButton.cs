using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BaseActionButton : MonoBehaviour
{
    public Action ActionButtonEvent;
    [SerializeField] protected InputActionProperty ActionProp;
    protected virtual void OnEnable()
    {
        ActionProp.action.performed += OnActionPerformed;
    }
    protected virtual void OnDisable()
    {
        ActionProp.action.performed -= OnActionPerformed;
    }
    protected virtual void OnActionPerformed(InputAction.CallbackContext c)
    {
        ActionButtonEvent?.Invoke();
    }
}
