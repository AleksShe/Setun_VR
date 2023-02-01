using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmperButtonsController : MonoBehaviour
{
    [SerializeField] private VoltButton[] _buttons;
    [SerializeField] private AmperRotator _amperRotator;
    [SerializeField] private AOSAmpermetr _aosAmper;
    private int _currentButton;
    private bool _firsttap = false;

    private void Awake()
    {
        foreach (var item in _buttons)
        {
            item.ButtonDownEvent += OnCurrentButtonChanged;
            item.NaprChangedEvent += OnNaprChanged;
        }
        _amperRotator.VoltageChangedEvent += OnVoltChanged;
    }

    private void OnCurrentButtonChanged(int number)
    {
        if (_firsttap)
            UpButton();
        else _firsttap = true;
        _currentButton = number;
    }
    private void UpButton()
    {
          _buttons[_currentButton].ResetButton();
    }
    private void OnVoltChanged(string value)
    {
        _aosAmper.SetVoltage(value);
    }
    private void OnNaprChanged(string value)
    {
        _aosAmper.SetNapr(value);
    }
}
