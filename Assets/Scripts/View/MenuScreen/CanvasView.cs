using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasView : MonoBehaviour
{
    [SerializeField] private Text _headTextExit;
    [SerializeField] private Text _commentTextExit;
    [SerializeField] private Text _evalTextExit;
    [SerializeField] private Text _taskText;
    [Space]
    [SerializeField] private TextMeshProUGUI _headerMessageText;
    [SerializeField] private TextMeshProUGUI _commentMessageText;
    [SerializeField] private TextMeshProUGUI _footerMessageText;  
    [SerializeField] private TextMeshProUGUI _exitText;
    [SerializeField] private TextMeshProUGUI _warnText;
    [Space]
    [SerializeField] private AlarmImageController _armImageController;


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

}
