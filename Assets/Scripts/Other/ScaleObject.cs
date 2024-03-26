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
    
    private float _scale = 70f;

    private Vector2 _size;
    private Vector2 _minSize = new Vector2(1721.076f, 908.49f);
   
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
            _image.rectTransform.sizeDelta += new Vector2(_scale, _scale);
            
            
        }
        else
        { 
            var rectTrans = _image.transform as RectTransform;
            _size = new Vector2(rectTrans.rect.width, rectTrans.rect.height);
            if (_size.x<= _minSize.x || _size.y <= _minSize.y)
                return;
            _image.rectTransform.sizeDelta -= new Vector2(_scale, _scale);
            

        }
       
    }
}
