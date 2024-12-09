using AosSdk.Core.PlayerModule;
using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;


public class CursorManager : MonoBehaviour
{
    [SerializeField] private Image _knob;
    [SerializeField] private Zoom _zoom;
    private DesktopPointer _pointer;
    private void Awake()
    {
        _pointer = _knob.GetComponent<DesktopPointer>();
    }

    private void Start()
    {
        //   Player.Instance.CanMove = false;
          Player.Instance.CursorLockMode = CursorLockMode.Locked;
    }

    public void EnableCursor(bool value)
    {     
        if (!value)
            Cursor.lockState = CursorLockMode.Locked;
        else
            Cursor.lockState = CursorLockMode.Confined;
        _zoom.CanZoom = !value;
        Cursor.visible = value;
        Player.Instance.CanMove = !value;
        _knob.enabled = !value;
        _pointer.enabled = !value;
        if(!value)
            Player.Instance.CursorLockMode = CursorLockMode.Confined;
        else
            Player.Instance.CursorLockMode = CursorLockMode.Locked;
    }
   
}
