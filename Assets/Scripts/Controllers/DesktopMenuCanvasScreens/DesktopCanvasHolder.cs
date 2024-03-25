using System.Linq;
using UnityEngine;

public class DesktopCanvasHolder : MonoBehaviour
{
    [SerializeField] private DesktopCanvasObject[] _desktopCanvasObjects;
    [SerializeField] private ModeController _modeController;
    [SerializeField] private GameObject _lineImage;
    public void DisableAllCanvases()
    {
        foreach (var canvas in _desktopCanvasObjects)
            canvas.gameObject.SetActive(false);
    }
    public void EnableCanvasByState(CanvasState state)
    {
        var canvasToShow = _desktopCanvasObjects.FirstOrDefault(c => c.CurrentState == state);
            if(canvasToShow!=null)
            canvasToShow.gameObject.SetActive(true);
        _modeController.CurrentInteractScreen.EnableLocationObject(true);
        _modeController.CurrentInteractScreen.EnableTimerObject(true);
        _lineImage.gameObject.SetActive(true);
    }
}
