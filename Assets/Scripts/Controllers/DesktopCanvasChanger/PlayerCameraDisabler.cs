using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCameraDisabler : MonoBehaviour
{
    [SerializeField] private GameObject _playerDesktopCamera;
    [SerializeField] private Image _knob;
    private DesktopPointer _pointer;
    private void Awake()
    {
        _pointer = _knob.GetComponent<DesktopPointer>();
    }
    public void EnableDesktopCamera(bool active)
    {
        if(!active)
        {
            InstanceHandler.Instance.HelpTextController.HideReactionText();
            InstanceHandler.Instance.HelpTextController.HideHelperText();
        }   
        _playerDesktopCamera.SetActive(active);
        _knob.enabled = active;
        _pointer.enabled = active;
    }
}