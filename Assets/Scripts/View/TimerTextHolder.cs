using System;
using TMPro;
using UnityEngine;

public class TimerTextHolder : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    private Timer _timer;
    private void Awake()
    {
        _timer = new Timer();
    }
    public void ShowTimerText(string time)
    {
        _timer.TimeChanger(Convert.ToDouble(time));
        _timerText.text = _timer.ReturnTime();
    }
}
