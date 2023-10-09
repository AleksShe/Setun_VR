using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextObjectUi : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private void Awake()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }
    public void SetText(string text, TextAlignmentOptions options)
    {
        if (_text == null)
            return;
        _text.alignment = options;
        _text.text = HtmlToText.Instance.HTMLToTextReplace(text);
    }
    public string Text => _text.text;
}
