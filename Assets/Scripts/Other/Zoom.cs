using AosSdk.Core.Utils;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Zoom : MonoBehaviour
{
    [SerializeField] private InputActionProperty _wheelAction;
    [SerializeField] private Camera _playerCamera;
    private float _zoomValue;
    private float _currentValue;

    private float _maxZoomValue = 15;
    private float _minZoomValue = 75;

    public bool CanZoom = true;

    private float _zoom;
    private void Start()
    {
        _zoomValue = _playerCamera.fieldOfView;
    }
    private void OnEnable()
    {
        _wheelAction.action.performed += OnMouseWheelSmooth;
    }
    private void OnDisable()
    {
        _wheelAction.action.performed -= OnMouseWheelSmooth;
    }
    public void ResetZoomCamera()
    {
        _playerCamera.fieldOfView = 75;
    }
    private void OnMouseWheel(InputAction.CallbackContext obj)
    {
        if (!CanZoom || _zoomValue < _maxZoomValue || _zoomValue > _minZoomValue)
            return;
        _zoom = obj.ReadValue<float>();

        if (_zoom > 0)
        {
            _zoomValue -= 15;
            if (_zoomValue < _maxZoomValue)
                _zoomValue = _maxZoomValue;
        }

        else
        {
            _zoomValue += 15;
            if (_zoomValue > _minZoomValue)
                _zoomValue = _minZoomValue;
        }
        _playerCamera.fieldOfView = _zoomValue;
    }

    private void OnMouseWheelSmooth(InputAction.CallbackContext obj)
    {
        if (!CanZoom || _zoomValue < _maxZoomValue || _zoomValue > _minZoomValue)
            return;
        _zoom = obj.ReadValue<float>();
        StartCoroutine(ChangeZoom(_zoom));
    }

    private IEnumerator ChangeZoom(float zoom)
    {
        _currentValue = _playerCamera.fieldOfView;
        if (zoom > 0)
        {

            _zoomValue -= 15;
            if (_zoomValue < _maxZoomValue)
                _zoomValue = _maxZoomValue;
            else
            {
                while (_zoomValue < _currentValue)
                {
                    _currentValue -= 1;
                    _playerCamera.fieldOfView = _currentValue;
                    yield return new WaitForSeconds(0.001f);
                }

            }
        }
        else
        {

            _zoomValue += 15;
            if (_zoomValue > _minZoomValue)
                _zoomValue = _minZoomValue;
            else
            {
                while (_zoomValue > _currentValue)
                {
                    _currentValue += 1;
                    _playerCamera.fieldOfView = _currentValue;
                    yield return new WaitForSeconds(0.001f);
                }
            }

        }

    }

}
