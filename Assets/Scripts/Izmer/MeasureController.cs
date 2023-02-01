using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeasureController : MonoBehaviour
{
    [SerializeField] private PointerDevice _pointerDevice;
    [SerializeField] private API _api;

    private string _measuretext;
    private string _type;
    private string _blackValue;
    private string _redValue;
    private string _pointerValue;

   public void SetDeviceValue(float value)
    {
        _pointerValue = _pointerDevice.SetValue(value);
        _measuretext = $"measure_device:{_type}:{_blackValue}:{_redValue}:{_pointerValue}";
        _api.InvokeOnMeasure(_measuretext);
    }

    public void SetTypeText(string type)
    {
        _type = type;
        ReturnMeasureText();
    }
    public void SetRedText(string red)
    {
        _redValue = red;
        ReturnMeasureText();
    }
    public void SetBlackText(string black)
    {
        _blackValue = black;
        ReturnMeasureText();
    }
    public void ReturnMeasureText()
    {
        _pointerValue = null;
        if (_type != null && _blackValue != null && _redValue != null)
        {
            _measuretext = $"measure_device:{_type}:{_blackValue}:{_redValue}:{_pointerValue}";
        }
        else
        {
            _pointerDevice.SetValue(0);
            _measuretext = $"measure_device:{_type}:{_blackValue}:{_redValue}:{_pointerValue}";
          
        }
        _api.InvokeOnMeasure(_measuretext);
    }
}
