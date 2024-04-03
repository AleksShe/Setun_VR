using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScreenUIButton : BaseUIButton
{
    [SerializeField] protected GameObject _catoLogoImage;
    [SerializeField] protected GameObject _guideButton;
    [SerializeField] protected GameObject _startButton;
    [SerializeField] protected GameObject _hideStartText;
    [SerializeField] protected GameObject _showFaultText;
    
    protected override void Click()
    {
        gameObject.SetActive(false);
        _catoLogoImage.SetActive(false);
        _guideButton.SetActive(false);
        _startButton.SetActive(true);
        _hideStartText.SetActive(false);
        _showFaultText.SetActive(true);


    }

    
}
