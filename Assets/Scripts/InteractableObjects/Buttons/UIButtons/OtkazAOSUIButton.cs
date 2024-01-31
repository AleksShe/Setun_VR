using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OtkazAOSUIButton : BaseUIButton
{
    [SerializeField] private string _buttonId;
    [SerializeField] private AnswerUIButton _answerButton;
    [SerializeField] private PlaceUiButton _placeUiButton;
    [SerializeField] private Image _selectedImage;
    [SerializeField] private Sprite _selectedOk;
    [SerializeField] private Sprite _selectedNotOk;
   

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
            _placeUiButton.SetDotSprite(true);
            _answerButton.SetColor();
            _answerButton.SetId(_buttonId);
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
}
