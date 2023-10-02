using UnityEngine;

public class HelpTextController : MonoBehaviour
{
    [SerializeField] private ModeController _modeController;
    [SerializeField] private MovingTextWindow _helperWindow;
    [SerializeField] private MovingTextWindow _reactionWindow;
    [SerializeField] private HelperCanvas _helperCanvas;
    public void ShowHelperText(Transform pos, string text)
    {
        if (!_modeController.VrMode)
        {
            _helperCanvas.EnableHelperWindow(true);
            _helperCanvas.SetHelperText(text);
        }
        else
        {
            _helperWindow.SetPosition(pos);
            _helperWindow.ShowWindowWithText(text);
        }
    }
    public void HideHelperText()
    {
        if (!_modeController.VrMode)
        {
            _helperCanvas.EnableHelperWindow(false);
            _helperCanvas.SetHelperText("");
        }
        else
            _helperWindow.HidetextHelper();
    }
    public void SetReactionText(string text)
    {
        if (!_modeController.VrMode)
        {
            _helperCanvas.SetReactionText(text);
            _helperCanvas.EnableReactionWindow(true);
        }
          
        else
            _reactionWindow.ShowWindowWithText(text);
    }
    public void SetReactionPosition(Transform pos)
    {
        if (!_modeController.VrMode)
            return;
        _reactionWindow.SetPosition(pos);
    }
    public void HideReactionText()
    {
        if (!_modeController.VrMode)
        {
            _helperCanvas.EnableReactionWindow(false);
            _helperCanvas.SetReactionText("");
        }
        else
            _reactionWindow.HidetextHelper();
    }
}
