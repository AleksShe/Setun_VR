using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlarmImageController : MonoBehaviour
{
    [SerializeField] private Sprite _okImage;
    [SerializeField] private Sprite _notOkImage;   
    [SerializeField] private Image _alarmImage;
  


    public void SetAlarmImage(string imageName)
    {
        if (imageName == "0")
        {
            _alarmImage.sprite = _okImage;
        }
        else if (imageName == "1")
        {
            _alarmImage.sprite = _notOkImage;
        }
        else if(imageName == "none") 
        {
            _alarmImage.gameObject.SetActive(false);
        }
       
    }
}
