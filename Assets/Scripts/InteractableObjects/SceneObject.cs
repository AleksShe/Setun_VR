using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.UI;

public class SceneObject : BaseObject
{
    public bool NonAOS;

    [SerializeField] protected Transform HelperPos;
    [SerializeField] protected OutlineCore[] OutlineObjects;

    protected string HelperName;
    protected  void Start()
    {
        if (!NonAOS)
        {
            EnableObject(false);
            InstanceHandler.Instance.AOSColliderActivator.AddSceneObject(this);
            SceneAOSObject = GetComponent<SceneAosObject>();
        }
    }
    public override void OnHoverIn(InteractHand interactHand)
    {
        if (HelperPos != null)
        {
            InstanceHandler.Instance.ObjectsInfoWindow.SetPosition(HelperPos);
            InstanceHandler.Instance.ObjectsInfoWindow.ShowWindowWithText(HelperName);
        }
        EnableOutlines(true);
     }
    public override void OnHoverOut(InteractHand interactHand)
    {
        InstanceHandler.Instance.ObjectsInfoWindow.HidetextHelper();
        EnableOutlines(false);
    }
    public override void EnableObject(bool value)
    {
        if (GetComponent<Collider>() != null)
            GetComponent<Collider>().enabled = value;
        if (GetComponent<SpriteRenderer>() != null)
            GetComponent<SpriteRenderer>().enabled = value;
        if (GetComponent<Image>() != null) 
            GetComponent<Image>().enabled = value;
    }
    public virtual void SetHelperName(string value)
    {
        HelperName = value;
    }
    public string GetAOSName()
    {
        if (SceneAOSObject != null)
            return SceneAOSObject.ObjectId;
        else return null;
    }
    protected void EnableOutlines(bool value)
    {
        if (OutlineObjects != null)
            foreach (var outline in OutlineObjects)
            {
                if (outline != null)
                {
                    outline.enabled = value;
                    outline.OutlineWidth = 3;
                }
            }
    }
}
