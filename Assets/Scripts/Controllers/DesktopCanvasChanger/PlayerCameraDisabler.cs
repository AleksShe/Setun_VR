using AosSdk.Core.PlayerModule;
using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCameraDisabler : MonoBehaviour
{
    [SerializeField] private GameObject _interactHelpers;
    [SerializeField] private GameObject _menuCanvas;
    [SerializeField] private Image _knob;
    [SerializeField] private Zoom _zoom;
    private DesktopPointer _pointer;
    private void Awake()
    {
        _pointer = _knob.GetComponent<DesktopPointer>();
    }
    public void EnableDesktopCamera(bool active)
    {
        if(active)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Player.Instance.CanMove = true;
            _interactHelpers.SetActive(true);
            _menuCanvas.SetActive(false);
            _zoom.CanZoom = true;
        }
        else if(!active)
        {
            InstanceHandler.Instance.HelpTextController.HideReactionText();
            InstanceHandler.Instance.HelpTextController.HideHelperText();
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            Player.Instance.CanMove = false;
            _interactHelpers.SetActive(false);
            _menuCanvas.SetActive(true);
            _zoom.CanZoom = false;
            _zoom.ResetZoomCamera();
        }
        _knob.enabled = active;
        _pointer.enabled = active;
    }
}
