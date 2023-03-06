using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
public class EscButton : MonoBehaviour
{
    public UnityAction OnEscClick;
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
        InstanceHandler.Instance.Teleporter.TeleportToMenu();
        OnEscClick?.Invoke();
    }

}
