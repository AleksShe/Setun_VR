using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DesktopMenuScreen : BaseMenuScreen
{
    [SerializeField] private Text _infoHeaderText;
    [SerializeField] private Text _infoText;
    [SerializeField] private Text _exitSureText;
    [SerializeField] private Text _exitText;
    [SerializeField] private Text _warnText;  
    [Space]
    [SerializeField] private Text _headTextExit;
    [SerializeField] private Text _commentTextExit;
    [SerializeField] private Text _evalTextExit;  
    [Space]
    [SerializeField] private Text _headerMessageText;
    [SerializeField] private Text _commentMessageText;
    [SerializeField] private Text _footerMessageText;
    [Space]
    [SerializeField] private AlarmImageController _armImageController;
    [SerializeField] private DesktopCanvasHolder _desktopCanvasHolder;
    [SerializeField] private GameObject _menu;

    [SerializeField] private GameObject _hideBackButton;
    [SerializeField] private GameObject _showBackButton;
    [SerializeField] private GameObject _resultPanel;

    public override void SetMenuText(string headText, string commentText, string exitSureText)
    {
        Debug.Log(headText+ commentText+ exitSureText);
        _infoHeaderText.text = HtmlToText.Instance.HTMLToTextReplace(headText);
        _infoText.text = HtmlToText.Instance.HTMLToTextReplace(commentText);
        _exitText.text = HtmlToText.Instance.HTMLToTextReplace(exitSureText);
    }
    public override void SetExitText(string exitText, string warnText)
    {

        _exitSureText.text = HtmlToText.Instance.HTMLToTextReplace(exitText);
        _warnText.text = HtmlToText.Instance.HTMLToTextReplace(warnText);
    }
    public override void ShowMessageScreen(string headText, string commentText, string footerText, string alarmImg)
    {
        _desktopCanvasHolder.DisableAllCanvases();     
        _desktopCanvasHolder.EnableCanvasByState(CanvasState.Last);
        ShowMessageScreen();
        _armImageController.SetAlarmImage(alarmImg);
        SetMessageText(headText, commentText,footerText);
       
    }
    public override void ShowLastScreen(string headText, string commentText, string evalText)
    {
        _desktopCanvasHolder.DisableAllCanvases();
        _desktopCanvasHolder.EnableCanvasByState(CanvasState.MainMenu);
       
        _showBackButton.SetActive(true);
        _hideBackButton.SetActive(false);
        _resultPanel.SetActive(true);
        _menu.SetActive(true);
        SetResultText(headText, commentText, evalText);
       
    }
    private void SetMessageText(string headText, string commentText,string footerText)
    {
        _headerMessageText.text = headText;
        _commentMessageText.text = commentText;
        _footerMessageText.text = footerText;
    }
    private void SetResultText(string headText, string commentText, string evalText)
    {
        _headTextExit.text = headText;
        _commentTextExit.text = commentText;
        _evalTextExit.text = evalText;
    }
    private void ShowMessageScreen()
    {
        _desktopCanvasHolder.EnableCanvasByState(CanvasState.Last);
    }

    public override void ShowMenuScreen(bool active)
    {
        _desktopCanvasHolder.DisableAllCanvases();
        _menu.SetActive(active);
        if (active)
        {
            _desktopCanvasHolder.EnableCanvasByState(CanvasState.MainMenu);
            _desktopCanvasHolder.EnableCanvasByState(CanvasState.Menu);
        }
    }
    public override void SetExitText(string headText, string commentText, string evalText)
    {
        _headTextExit.text = HtmlToText.Instance.HTMLToTextReplace(headText);
        _commentTextExit.text = HtmlToText.Instance.HTMLToTextReplace(commentText);
        _evalTextExit.text = HtmlToText.Instance.HTMLToTextReplace(evalText);
    }
}
