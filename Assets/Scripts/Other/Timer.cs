using System;
public class Timer
{
    private TimeSpan _time;

    public void TimeChanger(double second) => _time = TimeSpan.FromSeconds(second);
    public string GetFormattedTime()
    {
        return string.Format("{0:00}:{1:00}", _time.Minutes, _time.Seconds);
    }
}
