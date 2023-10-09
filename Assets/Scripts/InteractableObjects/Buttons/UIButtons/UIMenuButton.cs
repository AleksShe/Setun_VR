using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]

public class UIMenuButton : BaseUIButton
{
    public delegate void UIMenuButtonClicked();
    public event UIMenuButtonClicked ButtonClickedEvent;
    [SerializeField] private GameObject _showScreen;
    [SerializeField] private GameObject _hideScreen;

    protected override void Click()
    {
        _showScreen.SetActive(true);
        _hideScreen.SetActive(false);
        ButtonClickedEvent?.Invoke();
    }
}
