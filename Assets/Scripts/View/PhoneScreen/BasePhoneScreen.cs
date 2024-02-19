using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePhoneScreen : MonoBehaviour
{
    [SerializeField] protected GameObject Phone;
    public bool ActiveSelf => Phone.activeSelf;
    public abstract void ActivatePhone(bool active);
    public abstract void ActivatePhoneMainScreen(bool active);
    public abstract void ActivatePhoneDialogScreen(bool active);
    public abstract void AddItem(string text, DialogRole role);
    public abstract void AddItem(string id, string text);
    public abstract void ClearItemsList();
    public abstract void SetPhoneHeader(string text);
}
