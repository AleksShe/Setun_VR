using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartCanvas : BaseCanvas
{
    [SerializeField] private TextMeshProUGUI _headerText;
    [SerializeField] private TextMeshProUGUI _commentText;
    [SerializeField] private TextMeshProUGUI _nextButtonText;

    public void EnableStartScreen(string headerText, string commentText, string buttonText)
    {
        _headerText.text = headerText;
        _commentText.text = commentText;
        _nextButtonText.text = buttonText;
    }
}
