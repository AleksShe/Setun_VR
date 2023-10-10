using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CanvasState
{
    None,
    Start,
    Menu,
    Arm,
    Phone,
    Last,
    Other
}
public abstract class GameCanvasBase : MonoBehaviour
{
    [SerializeField] protected CanvasView CanvasText;
    [SerializeField] protected NextButton NextButton;
    [SerializeField] protected TimerTextHolder TimerTextHolder;
    [SerializeField] protected LocationTextHolder LocationText;

    public delegate void ScreenShow();
    public event ScreenShow LastScreenShowEvent;
    public event ScreenShow ResultScreenShowEvent;

    protected CanvasState CurrentState;
    protected const string DIALOG_POINT = "OnDialogPoint";
    private void Awake()
    {
        LastScreenShowEvent += OnShowLastScreen;
        ResultScreenShowEvent += OnShowResultLastScreen;
        CanvasEnableObject.CanvasEnableEvent += ShowCanvas;
    }
    public virtual void SetStartScreenText(string headerText, string commentText, string buttonText, NextButtonState state)
    {
        CanvasText.SetStartScreenText(headerText, commentText, buttonText);
        NextButton.CurrentState = state;
    }
    protected virtual void OnShowLastScreen()
    {
    }
    protected virtual void OnShowResultLastScreen()
    {
    }
    public virtual void ShowCanvas(CanvasState state)
    {
    }
    public void SetTimerText(string timerText)
    {
        TimerTextHolder.ShowTimerText(timerText);
    }
    public void SetLocationText(string location)
    {
        LocationText.SetLocationText(location);
    }
    public void SetDialogHeaderText(string text)
    {
        CanvasText.SetDialogHeadertext(text);
    }
    public void EnableDialogCanvas(string text)
    {
        if (text == DIALOG_POINT)
        {
            CanvasText.EnableMainMenuDialogCanvas(false);
            CanvasText.EnableDialogBoxCanvas(true);
        }
    }
    public virtual void SetLastScreenText(string headertext, string commentText)
    {
        LastScreenShowEvent?.Invoke();
        CanvasText.SetText(headertext, commentText);
    }
    public virtual void SetResultScreenText(string headertext, string commentText, string evalText)
    {
        ResultScreenShowEvent?.Invoke();
        CanvasText.SetText(headertext, commentText, evalText);
    }
    public virtual void SetExitText(string exitText, string warntext)
    {
        CanvasText.SetExitText(exitText, warntext);
    }
    public virtual void SetMenuText(string headText, string commentText, string exitSureText)
    {
        CanvasText.SetMenuText(headText, commentText, exitSureText);
    }

    public virtual void AddTextObjectUiButton(string id, string name)
    {
    }
    public virtual void AddTextObjectUi(string name,DialogRole role)
    {
    }

}
