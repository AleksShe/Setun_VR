using AosSdk.Core.PlayerModule.Pointer;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ScaleObject : MonoBehaviour
{

    [SerializeField] private InputActionProperty _wheelAction;
    [SerializeField] private Image _image;
    
    private float _scale = 10f;
    
   
    private bool _canZoom = true;
  
    private void OnEnable()
    {
        _wheelAction.action.performed += OnMouseScale;
    }
    private void OnDisable()
    {
        _wheelAction.action.performed -= OnMouseScale;
    }
   

    private void OnMouseScale(InputAction.CallbackContext obj)
    {
        if (!_canZoom)
            return;
        float _zoom = obj.ReadValue<float>();
        if (_zoom > 0)
        {
            _image.rectTransform.sizeDelta += new Vector2(30, 30);
            

        }
        else
        {
            _image.rectTransform.sizeDelta -= new Vector2(30, 30);

        }
       
    }
}
