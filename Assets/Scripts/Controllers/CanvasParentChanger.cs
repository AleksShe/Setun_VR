using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasParentChanger : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private CursorManager _cursorManager;
    [SerializeField] private MouseRayCastHandler _mouseRayCastHandler;
    [SerializeField] private BaseActionObject _backActionObject;
    private Camera _camera;
    public void ChangeCameraParent(Camera camera)
    {
        _mainCamera.enabled = false;
        _camera = camera;
        _mouseRayCastHandler.SetActionCamera(_camera);
        _camera.enabled = true;
        _canvas.transform.SetParent(_camera.transform);
        _cursorManager.EnableCursor(true);
        SceneObjectsHolder.Instance.CurrentState = PlayerState.Look;
        _backActionObject.Enable();
    }
    public void RevertCamera()
    {
        _mouseRayCastHandler.SetActionCamera(null);
        _camera.enabled = false;
        _camera = null;
        _mainCamera.enabled = true;
        _canvas.transform.SetParent(_mainCamera.transform);
        _cursorManager.EnableCursor(false);
        SceneObjectsHolder.Instance.CurrentState = PlayerState.Walk;
        _backActionObject.Disable();
    }
}
