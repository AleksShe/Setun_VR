using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AosSdk.Core.PlayerModule;
using TMPro;
using System.Linq;

public class MainMenuCanvas : BaseCanvas
{
    [SerializeField] private EscButton _escButton;
    [SerializeField] private GameObject[] _allMenuScreens;
    [SerializeField] private GameObject _mainMenuScreen;
    [Space]
    [SerializeField] private TextMeshProUGUI _infoHeaderText;
    [SerializeField] private TextMeshProUGUI _infoText;
    [SerializeField] private TextMeshProUGUI _exitSureText;
    [SerializeField] private TextMeshProUGUI _exitText;
    [SerializeField] private TextMeshProUGUI _evalText;
    [SerializeField] private TextMeshProUGUI _warnText;
    public void ShowCanvasByName(string screenName)
    {
          foreach (var screen in _allMenuScreens)
        {
            screen.SetActive(false);
        }
      var screenToshow = _allMenuScreens.FirstOrDefault(s => s.name == screenName);
        screenToshow.SetActive(true);
    }
    private void OnEnable()
    {
        _escButton.OnEscClick += OnShowMenu;
    }
    private void OnDisable()
    {
        _escButton.OnEscClick -= OnShowMenu;
    }
    private void OnShowMenu()
    {
        ShowCanvasByName("MainMenu");
    }
    public void SetMenuText(string headText, string commentText, string exitSureText)
    {
        _infoHeaderText.text = HtmlToText.Instance.HTMLToTextReplace(headText);
        _infoText.text = HtmlToText.Instance.HTMLToTextReplace(commentText);
        _exitSureText.text = HtmlToText.Instance.HTMLToTextReplace(exitSureText);
    }

    public void SetExitText(string exitText, string warntext)
    {
        _exitText.text = HtmlToText.Instance.HTMLToTextReplace(exitText);
        _warnText.text = HtmlToText.Instance.HTMLToTextReplace(warntext);
    }
    public void SetText(string headText, string commentText)
    {
        _infoHeaderText.text = headText;
        _infoText.text = commentText;
    }
    public void SetText(string headText, string commentText, string evalText)
    {
        _infoHeaderText.text = headText;
        _infoText.text = commentText;
        _evalText.text = evalText;
    }

}
