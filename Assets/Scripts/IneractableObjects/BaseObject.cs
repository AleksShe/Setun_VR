using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;


public class BaseObject : MonoBehaviour, IClickAble, IHoverAble
{
    public bool Button;
    public bool IsHoverable { get; set; } = true;
    public bool IsClickable { get; set; } = true;

    [SerializeField] protected SceneAosObject SceneAOSObject;

    protected string HelperName;

    public virtual void OnClicked(InteractHand interactHand)
    {
        if (SceneAOSObject == null)
            return;
        SceneAOSObject.InvokeOnClick();
    }

    public virtual void OnHoverIn(InteractHand interactHand)
    {
    }
    public virtual void OnHoverOut(InteractHand interactHand)
    {
    }
    public void SetHelperName(string value)
    {
        HelperName = value;
    }
    public string GetAOSName()
    {
        if (SceneAOSObject != null)
            return SceneAOSObject.ObjectId;
        else return null;
    }
    public void EnableObject(bool value)
    {
        if (GetComponent<Collider>() != null)
            GetComponent<Collider>().enabled = value;
        if (GetComponent<SpriteRenderer>() != null)
            GetComponent<SpriteRenderer>().enabled = value;
    }
}