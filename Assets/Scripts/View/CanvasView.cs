using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _headerText;
    [SerializeField] private TextMeshProUGUI _commentText;
    [SerializeField] private TextMeshProUGUI _nextButtonText;
    [Space]
    [SerializeField] private Text _headTextExit;
    [SerializeField] private Text _commentTextExit;
    [SerializeField] private Text _evalTextExit;
    [Space]
    [SerializeField] private TextMeshProUGUI _infoHeaderText;
    [SerializeField] private TextMeshProUGUI _infoText;
    [SerializeField] private TextMeshProUGUI _headerMessageText;
    [SerializeField] private TextMeshProUGUI _commentMessageText;
    [SerializeField] private TextMeshProUGUI _footerMessageText;  
    [SerializeField] private TextMeshProUGUI _evalText;
    [SerializeField] private TextMeshProUGUI _exitText;
    [SerializeField] private TextMeshProUGUI _warnText;
    [SerializeField] private TextMeshProUGUI _dialogHeaderText;
    [Space]
    [SerializeField] private GameObject _backToMenuButton;
    [SerializeField] private GameObject _exitButton;
    [SerializeField] private GameObject _mainMenuDialogCanvas;
    [SerializeField] private GameObject _dialogBoxCanvas;
    [SerializeField] private AlarmImageController _armImageController;


    public void SetStartScreenText(string headerText, string commentText, string buttonText)
    {
        _headerText.text = HtmlToText.Instance.HTMLToTextReplace(headerText);
        _commentText.text = HtmlToText.Instance.HTMLToTextReplace(commentText);
        _nextButtonText.text = HtmlToText.Instance.HTMLToTextReplace(buttonText);
    }
    public void SetMenuText(string headText, string commentText, string exitSureText)
    {
        Debug.Log(commentText + "Set Menu Text");
        _infoHeaderText.text = HtmlToText.Instance.HTMLToTextReplace(headText);
        _infoText.text = HtmlToText.Instance.HTMLToTextReplace(commentText);
        _exitText.text = HtmlToText.Instance.HTMLToTextReplace(exitSureText);
    }
    public void SetExitText(string exitText, string warntext)
    {
        Debug.Log(exitText + warntext);
        _exitText.text = HtmlToText.Instance.HTMLToTextReplace(exitText);
        _warnText.text = HtmlToText.Instance.HTMLToTextReplace(warntext);
    }
    public void SetText(string headText, string commentText,string footerText,string alarmImg)
    {
        _headerMessageText.text = HtmlToText.Instance.HTMLToTextReplace(headText);
        _commentMessageText.text = HtmlToText.Instance.HTMLToTextReplace(commentText);
        _footerMessageText.text = HtmlToText.Instance.HTMLToTextReplace(footerText);
        _armImageController.SetAlarmImage(alarmImg);
    }
    public void SetExitText(string headText, string commentText, string evalText)
    {
        _headTextExit.text = HtmlToText.Instance.HTMLToTextReplace(headText);
        _commentTextExit.text = HtmlToText.Instance.HTMLToTextReplace(commentText);
        _evalTextExit.text = HtmlToText.Instance.HTMLToTextReplace(evalText);
    }
    public void ShowExitButton()
    {
        _backToMenuButton.SetActive(false);
        _exitButton.SetActive(true);
    }
    public void SetDialogHeadertext(string text)
    {
        _dialogHeaderText.text = text;
    }
    public void EnableMainMenuDialogCanvas(bool value)
    {
        _mainMenuDialogCanvas.SetActive(value);
    }
    public void EnableDialogBoxCanvas(bool value)
    {
        _dialogBoxCanvas.SetActive(value);
    }
}
