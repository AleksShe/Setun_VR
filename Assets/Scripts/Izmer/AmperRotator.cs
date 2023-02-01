using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AmperRotator : MonoBehaviour
{
    public UnityAction<string> VoltageChangedEvent;
    [SerializeField] private GameObject _lid;
    [SerializeField] private AmperLidButton _leftButton;
    [SerializeField] private AmperLidButton _rightButton;
    [SerializeField] private PointerDevice _device;
    private float _rotator;
    private void OnEnable()
    {
        _leftButton.RotateButton += OnRotateLid;
        _rightButton.RotateButton += OnRotateLid;
    }
    private void OnDisable()
    {
        _leftButton.RotateButton -= OnRotateLid;
        _rightButton.RotateButton -= OnRotateLid;
    }

    public void OnRotateLid(bool value)
    {
        if (value)
        {
            _rotator += 15;
            CheckRotatorDegree();
            GetVoltage(_rotator);
            _lid.transform.localRotation = Quaternion.Euler(0, _rotator, 0);
        }
        else
        {
            _rotator -= 15;
            CheckRotatorDegree();
            GetVoltage(_rotator);
            _lid.transform.localRotation = Quaternion.Euler(0, _rotator, 0);
        }
    }
    private void CheckRotatorDegree()
    {
        if (_rotator < 0)
            _rotator = 345;
        else if (_rotator > 345)
            _rotator = 0;
    }
    public void GetVoltage(float value)
    {
        if (value == 345)
        {
            _device.SetMaxValue(1000);
            VoltageChangedEvent?.Invoke("V");
        }
        else if (value == 330)
        {
            _device.SetMaxValue(500);
            VoltageChangedEvent?.Invoke("V");
        }
        else if (value == 315)
        {
            _device.SetMaxValue(250);
            VoltageChangedEvent?.Invoke("V");
        }
        else if (value == 300)
        {
            _device.SetMaxValue(100);
            VoltageChangedEvent?.Invoke("V");
        }
        else if (value == 285)
        {
            _device.SetMaxValue(50);
            VoltageChangedEvent?.Invoke("V");
        }
        else if (value == 270)
        {
            _device.SetMaxValue(25);
            VoltageChangedEvent?.Invoke("V");
        }
        else if (value == 255)
        {
            _device.SetMaxValue(10);
            VoltageChangedEvent?.Invoke("V");
        }
        else if (value == 240)
        {
            _device.SetMaxValue(2.5f);
            VoltageChangedEvent?.Invoke("V");
        }
        else if (value == 225)
        {
            _device.SetMaxValue(0.5f);
            VoltageChangedEvent?.Invoke("V");
        }
        else if (value == 210)
        {
            _device.SetMaxValue(200);
            VoltageChangedEvent?.Invoke("R");
        }
        else if (value == 195)
        {
            _device.SetMaxValue(9999);
            VoltageChangedEvent?.Invoke("R");
        }
        else if (value == 180)
        {
            _device.SetMaxValue(9999);
            VoltageChangedEvent?.Invoke("R"); 
        }
        else if (value == 165)
        {
            VoltageChangedEvent?.Invoke("R");
        }
        else if (value == 150)
        {
            _device.SetMaxValue(9999);
            VoltageChangedEvent?.Invoke("R");
        }
        else if (value == 135)
        {
            _device.SetMaxValue(9999);
            VoltageChangedEvent?.Invoke("R");
        }
        else if (value == 120)
        {
            _device.SetMaxValue(0.5f);
            VoltageChangedEvent?.Invoke("mA");
        }
        else if (value == 105)
        {
            _device.SetMaxValue(1);
            VoltageChangedEvent?.Invoke("mA");
        }
        else if (value == 90)
        {
            _device.SetMaxValue(5);
            VoltageChangedEvent?.Invoke("mA");
        }
        else if (value == 75)
        {
            _device.SetMaxValue(10);
            VoltageChangedEvent?.Invoke("mA");
        }
        else if (value == 60)
        {
            _device.SetMaxValue(50);
            VoltageChangedEvent?.Invoke("mA");
        }
        else if (value == 45)
        {
            _device.SetMaxValue(0.25f);
            VoltageChangedEvent?.Invoke("A");
        }
        else if (value == 30)
        {
            _device.SetMaxValue(1);
            VoltageChangedEvent?.Invoke("A");
        }
        else if (value == 15)
        {
            _device.SetMaxValue(6);
            VoltageChangedEvent?.Invoke("A");
        }
        else
        {
            _device.SetMaxValue(0.001f);
            VoltageChangedEvent?.Invoke("");
        }
    }
}
