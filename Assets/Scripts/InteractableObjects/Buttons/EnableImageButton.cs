using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;
public class EnableImageButton : BaseButton
{
    [SerializeField] private GameObject _mapImage;

    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        if (_mapImage.activeSelf)
            _mapImage.SetActive(false);
        else
            _mapImage.SetActive(true);
    }
    private void DisableMap()
    {
        if (!_mapImage.activeSelf)
            return;
            _mapImage.SetActive(false);
    }
}
