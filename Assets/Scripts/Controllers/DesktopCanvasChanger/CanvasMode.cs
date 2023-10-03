using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMode : MonoBehaviour
{
    [SerializeField] private GameCanvasBase _deskCanvas;
    [SerializeField] private GameCanvasBase _vrCanvas;
    private GameCanvasBase _currentCanvas;
    private void Start()
    {
        _currentCanvas = InstanceHandler.Instance.ModeController.VrMode ? _vrCanvas : _deskCanvas;
        if(_currentCanvas==_deskCanvas)
            _vrCanvas.gameObject.SetActive(false);
        else _deskCanvas.gameObject.SetActive(false);
    }
    public void SetStartScreenText(string headerText, string commentText, string buttonText, NextButtonState state)
    {
        _currentCanvas.SetStartScreenText(headerText, commentText, buttonText, state);
        _currentCanvas.ShowCanvas(CanvasState.Start);
    }
    public void SetTimeText(string timerText)
    {
        _currentCanvas.SetTimerText(timerText);
    }
    public void SetLastScreenText(string headertext, string commentText)
    {
     _currentCanvas.SetLastScreenText(headertext, commentText);
    }
    public void SetResultScreenText(string headertext, string commentText, string evalText)
    {
        _currentCanvas.SetResultScreenText(headertext, commentText, evalText);
    }
    public void SetExitText(string exitText, string warntext)
    {
        _currentCanvas.SetExitText(exitText, warntext);
    }
    public void SetMenuText(string headText, string commentText, string exitSureText)
    {
        _currentCanvas.SetMenuText(headText, commentText,exitSureText);
    }
    public void SetLocationtext(string location)
    {
        _currentCanvas.SetLocationText(location);
    }
}
