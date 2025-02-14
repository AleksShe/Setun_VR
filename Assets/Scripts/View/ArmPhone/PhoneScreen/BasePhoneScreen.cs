using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePhoneScreen : BaseScreen
{
    public abstract void ActivatePhoneMainScreen(bool active);
    public abstract void ActivatePhoneDialogScreen(bool active);
    public abstract void AddItem(string text, DialogRole role);
    public abstract void AddItem(string id, string text);
    public abstract void ClearItemsList();
    public abstract void SetPhoneHeader(string text);
}
