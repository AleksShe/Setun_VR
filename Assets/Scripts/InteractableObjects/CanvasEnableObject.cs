using UnityEngine;
[RequireComponent(typeof(SceneAosObject))]
public class CanvasEnableObject : MonoBehaviour
{
    [SerializeField] private CanvasState _currentState;
    private SceneAosObject _aosObject;

    public delegate void CanvasEnable(CanvasState state);
    public static event CanvasEnable CanvasEnableEvent;

    private void Awake()
    {
        _aosObject = GetComponent<SceneAosObject>();
        _aosObject.OnClickObject += ChangeCanvasEvent;
    }
    private void ChangeCanvasEvent(object parameter)
    {
        CanvasEnableEvent?.Invoke(_currentState);
    }
}
