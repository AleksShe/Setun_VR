using AosSdk.Core.PlayerModule;
using System;
using UnityEngine;
using UnityEngine.UI;

public class NextUIButton : NextButton
{
    [SerializeField] private DesktopCanvas _dcCanvas;
    private Button _button;
    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() => OnClick());
    }
    public void OnClick()
    {
        if (CurrentState == NextButtonState.Start)
        {
            InstanceHandler.Instance.API.OnInvokeNavAction("next");
            NextButtonPressedEvent?.Invoke("next");
            Player.Instance.CanMove = false;
        }
        else if (CurrentState == NextButtonState.Fault)
        {
            InstanceHandler.Instance.API.OnInvokeNavAction("start");
            NextButtonPressedEvent?.Invoke("start");
            Player.Instance.CanMove = true;
            if(_dcCanvas != null) _dcCanvas.CanTeleport = true;
            
        }
    }
}
