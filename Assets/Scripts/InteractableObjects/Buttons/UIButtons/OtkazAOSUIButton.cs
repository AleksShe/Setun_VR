using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OtkazAOSUIButton : BaseUIButton
{
    [SerializeField] private string _buttonId;
    [SerializeField] private AnswerUIButton _answerButton;

    public bool Check = false;

    protected override void Click()
    {
        if (!Check)
        {

            foreach (var item in _answerButton.OtkazButtons)
            {
                if (item.Check)
                {
                    item.Click();
                }
            }
            Check = true;
            _answerButton.SetColor();
            _answerButton.SetId(_buttonId);

        }

        else
        {
            Check = false;
            _answerButton.SetColor();


        }


    }
}
