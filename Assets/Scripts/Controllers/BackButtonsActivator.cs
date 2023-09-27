using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonsActivator : MonoBehaviour
{
    private BackButton _currentBackButton;
    public void OnActivaBackButton(string text)
    {
        ActionToInvoke = text;
        EnableCurrentBackButton(true);
    }
    public string ActionToInvoke { get; set; }
    public void SetCurrentBackButton(BackButton backButtonObject) => _currentBackButton = backButtonObject;
    public BackButton GetCurrentBackButton()
    {
        if(_currentBackButton!=null)
        return _currentBackButton;
        else return null;
    }
    public void EnableCurrentBackButton(bool value)
    {
        if(_currentBackButton!=null)
        _currentBackButton.EnableObject(value);
    }
}
