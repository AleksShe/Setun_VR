using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AosSdk.Core.PlayerModule;
using TMPro;
using System.Linq;

public class MainMenuCanvas : BaseCanvas
{
    [SerializeField] private GameObject[] _allMenuScreens;
    [SerializeField] private GameObject _mainMenuScreen;
    [Space]
    [SerializeField] private TextMeshProUGUI _infoHeaderText;
    [SerializeField] private TextMeshProUGUI _infoText;
    [SerializeField] private TextMeshProUGUI _headerExitText;
    [SerializeField] private TextMeshProUGUI _commentExitText;
    [SerializeField] private TextMeshProUGUI _exitSureText;
    [SerializeField] private TextMeshProUGUI _evalText;
    [SerializeField] private TextMeshProUGUI _exitText;
    [SerializeField] private TextMeshProUGUI _warnText;
    [SerializeField] private GameObject _exitButton;
    public void ShowCanvasByName(string screenName)
    {
          foreach (var screen in _allMenuScreens)
        {
            screen.SetActive(false);
        }
      var screenToshow = _allMenuScreens.FirstOrDefault(s => s.name == screenName);
        screenToshow.SetActive(true);
    }
    public void SetMenuText(string headText, string commentText, string exitSureText)
    {
        Debug.Log($"Head Text {headText} Comment Text {commentText} ExitSure Text {exitSureText} FROM SETMENUTEXT");
        _infoHeaderText.text = HtmlToText.Instance.HTMLToTextReplace(headText);
        _infoText.text = HtmlToText.Instance.HTMLToTextReplace(commentText);
        _exitText.text = exitSureText;
    }

    public void SetExitText(string exitText, string warntext)
    {
        Debug.Log($"Exit Text {exitText} WARN Text {warntext} FROM SETEXIT TEXT");
        _exitText.text = HtmlToText.Instance.HTMLToTextReplace(exitText);
        _warnText.text = HtmlToText.Instance.HTMLToTextReplace(warntext);
    }
    public void SetText(string headText, string commentText)
    {
        Debug.Log($"Head Text {headText} Comment Text {commentText}  FROM SETTEXT");
        _headerExitText.text = headText;
        _commentExitText.text = commentText;
    }
    public void SetText(string headText, string commentText, string evalText)
    {
        Debug.Log($"Head Text {headText} Comment Text {commentText} EVAL TEXT {evalText} FROM SETTEXT3 Fields");
        _headerExitText.text = headText;
        _exitSureText.text = commentText;
        _evalText.text = evalText;
        InstanceHandler.Instance.Teleporter.CanTeleport = false;
        _exitButton.SetActive(true);
    }

}
