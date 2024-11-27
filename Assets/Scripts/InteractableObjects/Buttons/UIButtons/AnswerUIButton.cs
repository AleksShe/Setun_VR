using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerUIButton : BaseUIButton
{
    [SerializeField] private Text _answerButtonText;
    [SerializeField] private TextMeshProUGUI _attempText;
    private List<AnswerOptionsButton> _answerButtons = new List<AnswerOptionsButton>();
    private string _buttonId = "";
    private string _attemp = "Осталось попыток: 1";
    public List<AnswerOptionsButton> AnswerButtons => _answerButtons;
    protected override void Click()
    {
        API.OnReasonInvoke(_buttonId);
        SetText(_attemp);
    }

    public void SetColor()
    {

        foreach (var otkazButton in AnswerButtons)
        {
            if (otkazButton.Check)
            {

                Button.image.color = new Color(1, 1, 1, 1);
                Button.enabled = true;
                _answerButtonText.color = new Color(1, 1, 1, 1);
                return;
            }
            else
            {
                Button.image.color = new Color(1, 1, 1, 0.5f);
                Button.enabled = false;
                _answerButtonText.color = new Color(1, 1, 1, 0.4f);
            }
        }

    }
    public void SetId(string id)
    {
        _buttonId = id;
    }
    private void SetText(string attemptext)
    {
        _attempText.text = attemptext;
    }
    public void AddButton(List<AnswerOptionsButton> buttons)
    {
        _answerButtons = buttons;
    }
}
