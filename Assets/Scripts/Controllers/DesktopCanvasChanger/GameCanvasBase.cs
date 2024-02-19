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
    Other,
    MainMenu,
    Result
}
public abstract class GameCanvasBase : MonoBehaviour
{
    [SerializeField] protected CanvasView CanvasText;

    [SerializeField] protected GameObject _exitButtonMidle;
    [SerializeField] protected GameObject _exitButton;

    public delegate void ScreenShow();
    public event ScreenShow LastScreenShowEvent;
    public event ScreenShow ResultScreenShowEvent;

    protected CanvasState CurrentState;
    protected const string DIALOG_POINT = "OnDialogPoint";
    protected void Awake()
    {
        LastScreenShowEvent += OnShowLastScreen;
        ResultScreenShowEvent += OnShowResultLastScreen;
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
    public virtual void SetLastScreenText(string headertext, string commentText, string footerText, string alarmImg)
    {
        LastScreenShowEvent?.Invoke();
        CanvasText.SetText(headertext, commentText,footerText,alarmImg);
    }
    public virtual void SetResultScreenText(string headertext, string commentText, string evalText)
    {
        ResultScreenShowEvent?.Invoke();
        CanvasText.SetExitText(headertext, commentText, evalText);
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
