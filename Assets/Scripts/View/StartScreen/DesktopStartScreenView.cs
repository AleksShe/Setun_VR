using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DesktopStartScreenView : BaseStartScreenView
{
    [SerializeField] private CursorManager _cursorManager;
    [SerializeField] private GameObject _menuObject;
    [SerializeField] private TextMeshProUGUI _infoHeaderText;
    [SerializeField] private TextMeshProUGUI _inforCommentText;

    protected override void DisableStartScreen()
    {
        _menuObject.SetActive(false);
    }
    public override void SetStartScreenText(string headerText, string commentText, string headerFaultText, string commentFaultText)
    {
        base.SetStartScreenText(headerText, commentText, headerFaultText, commentFaultText);
        _cursorManager.EnableCursor(true);
        _infoHeaderText.text = headerFaultText;
        _inforCommentText.text = commentFaultText;
    }
    protected override void OnHideStartScreen(string value)
    {
        base.OnHideStartScreen(value);
        if (value == "start")
            _cursorManager.EnableCursor(false);
    }
}
