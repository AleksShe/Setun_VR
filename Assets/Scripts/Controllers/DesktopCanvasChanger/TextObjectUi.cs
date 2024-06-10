using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextObjectUi : MonoBehaviour
{
    private Text _text;
    private void Awake()
    {
        _text = GetComponentInChildren<Text>();
    }
    public void SetText(string text)
    {
        if (_text == null)
            return;    
        _text.text = HtmlToText.Instance.HTMLToTextReplace(text);
    }
    public string Text => _text.text;
}
