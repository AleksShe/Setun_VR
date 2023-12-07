using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnableObjectWithAction : MonoBehaviour
{
    [SerializeField] private InputActionProperty _action;
    [SerializeField] private GameObject _objectToEnable;
    private void Start() => _action.action.performed += OnActionPerformed;
    private void OnActionPerformed(InputAction.CallbackContext obj)
    {
        bool value = !_objectToEnable.activeSelf;
        _objectToEnable.SetActive(value);
    }
}
