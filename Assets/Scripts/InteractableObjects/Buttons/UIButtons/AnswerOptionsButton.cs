using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerOptionsButton : BaseUIButton
{
     
   
    [SerializeField] private Image _selectedImage;
    [SerializeField] private Sprite _selectedOk;
    [SerializeField] private Sprite _selectedNotOk;
    [SerializeField] private Text _text;
    private AnswerUIButton _answerButton;
    private PlaceDynamicUiButton _placeUiButton;
    private string _answerId;


    public bool Check = false;
    protected override void Click()
    {
        if (!Check)
        {

            foreach (var item in _answerButton.AnswerButtons)
            {
                if (item.Check)
                {
                     item.Click();
                }
            }
            Check = true;
            _placeUiButton.SetDotSprite(true);
            _answerButton.SetColor();
            _answerButton.SetId(_answerId);
            _selectedImage.sprite = _selectedOk;
        }

        else
        {
            Check = false;
            _answerButton.SetColor();
            _selectedImage.sprite = _selectedNotOk;
            _placeUiButton.SetDotSprite(false);
        }
    }
    public void SetButtonIdAndText(string buttonId,string text)
    {
        gameObject.name = buttonId;
        _text.text = text;
        _answerId = buttonId;
    }
    public void SetButtons(AnswerUIButton ansButton, PlaceDynamicUiButton placeButton)
    {
        _answerButton = ansButton;
        _placeUiButton = placeButton;
    }
}
