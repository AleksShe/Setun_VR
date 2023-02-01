using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : BaseButton
{
    [SerializeField] private GameObject _showScreen;
    [SerializeField] private GameObject _hideScreen;

    public override void OnClicked(InteractHand interactHand)
    {
        _showScreen.SetActive(true);
        _hideScreen.SetActive(false);
    }
}
