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
    [SerializeField] protected NextButton NextButton;
    [SerializeField] protected TimerTextHolder TimerTextHolder;
    [SerializeField] protected LocationTextHolder LocationText;
    [SerializeField] protected GameObject _catoImage;
    [SerializeField] protected GameObject _loadImage;
    [SerializeField] protected GameObject _exitButtonMidle;
    [SerializeField] protected GameObject _exitButton;

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
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    public void EnableStartButton()
    {
        NextButton.gameObject.SetActive(true);
    }
    public virtual void SetStartScreenText(string headerText, string commentText, string buttonText, NextButtonState state)
    {
        if (state == NextButtonState.Fault)
        {
            _catoImage.SetActive(false);
            buttonText = "Начать";
        }
          
        CanvasText.SetStartScreenText(headerText, commentText, buttonText);
        NextButton.CurrentState = state;
        _loadImage.SetActive(false);
        _exitButtonMidle.SetActive(false);
        _exitButton.SetActive(true);
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
