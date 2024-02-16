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
        if(_currentCanvas==_deskCanvas)
            _vrCanvas.gameObject.SetActive(false);
        else _deskCanvas.gameObject.SetActive(false);
    }
    public void SetStartScreenText(string headerText, string commentText, string buttonText, NextButtonState state)
    {
        _currentCanvas.EnableStartButton();
        _currentCanvas.SetStartScreenText(headerText, commentText, buttonText, state);
        _currentCanvas.ShowCanvas(CanvasState.Start);
    }

    public void SetLastScreenText(string headertext, string commentText,string footerText,string alarmImg)
    {
     _currentCanvas.SetLastScreenText(headertext, commentText, footerText, alarmImg);
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
    public void AddTextObjectUiButton(string id, string name)
    {
        _currentCanvas.AddTextObjectUiButton(id, name);
    }
    public  void AddTextObjectUi(string name,DialogRole role)
    {
        _currentCanvas.AddTextObjectUi(name,role);
    }
    public void SetDialogHeaderText(string text)
    {
        _currentCanvas.SetDialogHeaderText(text);
    }
    public void EnableDialogCanvas(string text)
    {
        _currentCanvas.EnableDialogCanvas(text);
    }
}
