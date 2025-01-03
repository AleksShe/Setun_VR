using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlarmImageController : MonoBehaviour
{
    [SerializeField] private Sprite _okImage;
    [SerializeField] private Sprite _notOkImage;   
    [SerializeField] private Sprite _infoImage;   
    [SerializeField] private Image _alarmImage;



    public void SetAlarmImage(string imageName)
    {
        if (imageName == "0")
        {
            _alarmImage.sprite = _okImage;
            _alarmImage.gameObject.SetActive(true);
        }
        else if (imageName == "1")
        {
            _alarmImage.sprite = _notOkImage;
            _alarmImage.gameObject.SetActive(true);
        }
        else if (imageName == "2")
        {
            _alarmImage.sprite = _infoImage;
            _alarmImage.gameObject.SetActive(true);
        }
        else if (imageName == "none")
        {
            _alarmImage.gameObject.SetActive(false);
        }

    }
}
