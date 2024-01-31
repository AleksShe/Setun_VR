using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnswerUIButton : BaseUIButton
{
    [SerializeField] private OtkazAOSUIButton[] _otkazButton;
    [SerializeField] private TextMeshProUGUI _answerButtonText;
    private string _buttonId="";
    public OtkazAOSUIButton[] OtkazButtons => _otkazButton;
    protected override void Click()
    {
        InstanceHandler.Instance.API.OnReasonInvoke(_buttonId);
        Debug.Log(_buttonId);
    }    

    public void SetColor()
    {
        
        foreach (var otkazButton in _otkazButton)
        {
            if (otkazButton.Check)
            {
               
                Button.image.color = new Color(1, 1, 1, 1);
                Button.enabled = true;
                _answerButtonText.color = new Color(1,1,1,1);
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
}
