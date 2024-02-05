using System.Linq;
using UnityEngine;

public class VRCanvas : GameCanvasBase
{
    [SerializeField] private MainMenuCanvas _mainMenuCanvas;
    [SerializeField] private BaseCanvas[] _baseCanvases;
    [SerializeField] private Teleporter _teleporter;

    private void OnEnable()
    {
        NextButton.NextButtonPressedEvent += OnHideStartScreen;
        _teleporter.TeleportEndEvent += OnEnableMenuScreen;
    }
    private void OnDisable()
    {
        NextButton.NextButtonPressedEvent -= OnHideStartScreen;
        _teleporter.TeleportEndEvent -= OnEnableMenuScreen;
    }
    public override void SetStartScreenText(string headerText, string commentText, string buttonText, NextButtonState state)
    {
        base.SetStartScreenText(headerText, commentText, buttonText, state);
        EnableCanvasByname("start");
    }
    public override void SetExitText(string exitText, string warntext)
    {
        InstanceHandler.Instance.MainMenuCanvas.SetExitText(exitText, warntext);
    }
    public override void SetMenuText(string headText, string commentText, string exitSureText)
    {
        InstanceHandler.Instance.MainMenuCanvas.SetMenuText(headText, commentText, exitSureText);
    }
    public override void SetLastScreenText(string headertext, string commentText, string footerText, string alarmImg)
    {
        InstanceHandler.Instance.MainMenuCanvas.ShowCanvasByName("LastWindow");
        InstanceHandler.Instance.MainMenuCanvas.SetText(headertext, commentText);
    }
    public override void SetResultScreenText(string headertext, string commentText, string evalText)
    {
        InstanceHandler.Instance.Teleporter.CanTeleport = false;
        //InstanceHandler.Instance.Teleporter.TeleportToMenu();
        InstanceHandler.Instance.MainMenuCanvas.ShowCanvasByName("LastWindow");
        InstanceHandler.Instance.MainMenuCanvas.SetText(headertext, commentText, evalText);
    }
    private void OnHideStartScreen(string value)
    {
        if (value != "start")
            return;
        EnableCanvasByname(null);
    }
    private void OnEnableMenuScreen(string value)
    {
        if (value != "menu")
            return;
        _mainMenuCanvas.EnableCanvas(true);
        _mainMenuCanvas.ShowCanvasByName("MainMenu");
    }
    private void EnableCanvasByname(string value)
    {
        foreach (var canvas in _baseCanvases)
        {
            canvas.EnableCanvas(false);
        }
        var canvasToShow = _baseCanvases.FirstOrDefault(c => c.CanvasName == value);
        if (canvasToShow != null)
            canvasToShow.EnableCanvas(true);
    }
}
