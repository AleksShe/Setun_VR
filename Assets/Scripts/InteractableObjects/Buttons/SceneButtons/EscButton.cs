using AosSdk.Core.PlayerModule;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
public class EscButton : MonoBehaviour
{
    public UnityAction EscClickEvent;
    [SerializeField] private InputActionProperty _menuAction;
    [SerializeField] private API _api;
    private void OnEnable()
    {
        _menuAction.action.performed += OnShowMenu;
    }
    private void OnDisable()
    {
        _menuAction.action.performed -= OnShowMenu;
    }
    private void OnShowMenu(InputAction.CallbackContext c)
    {
        EscClickEvent?.Invoke();
    }
}
