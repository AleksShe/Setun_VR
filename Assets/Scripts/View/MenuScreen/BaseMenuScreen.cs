using UnityEngine;

public abstract class BaseMenuScreen : MonoBehaviour
{
    public abstract void ShowMenuScreen(bool active);
    public abstract void SetMenuText(string headText, string commentText, string exitSureText);
    public abstract void SetExitText(string exitText, string warnText);
    public abstract void SetExitText(string headText, string commentText, string evalText);
    public abstract void ShowMessageScreen(string headText, string commentText, string footerText, string alarmImg);
    public abstract void ShowLastScreen(string headText, string commentText, string evalText);
    public abstract void ShowMenuButtons();
}
