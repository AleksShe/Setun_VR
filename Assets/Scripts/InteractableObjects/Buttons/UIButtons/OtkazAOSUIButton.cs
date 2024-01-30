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
            Debug.Log("Check");
            Check = true;
            _answerButton.SetColor(_buttonId);
            Debug.Log(_buttonId);
        }
           
        else
        {
            Check = false;
            _answerButton.SetColor("");
                       
        }
          
        
    }
}
