using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private TextMeshProUGUI _vrTimerText;
    [SerializeField] private Timer _timer;
    public void ShowTimerText(string time)
    {
        _timer.TimeChanger(Convert.ToDouble(time));

        _timerText.text = _timer.ReturnTime();
        _vrTimerText.text = _timer.ReturnTime();
    }
}
