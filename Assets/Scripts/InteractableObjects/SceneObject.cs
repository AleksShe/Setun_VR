using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SceneObject : BaseObject
{
    public bool NonAOS;

    [SerializeField] private GameObject[] _highlights;

    public Action<string> HelperTextEvent;
    public Action<ObjectWithAnimation> AddAnimationObjectEvent;
    public Action<IToolObject> SetToolObjectEvent;

    protected ObjectWithAnimation ObjectWithAnimation;
    protected IToolObject ToolObject;
    protected string HelperName;

    protected float EmissionValue = 0.5f;
    protected void Start()
    {
        if (!NonAOS)
        {
            EnableObject(false);
            SceneObjectsHolder.Instance.AddSceneObject(this);
        }
    }
    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        ObjectWithAnimation = GetComponent<ObjectWithAnimation>();
        if(ObjectWithAnimation!=null)
        {
            AddAnimationObjectEvent?.Invoke(ObjectWithAnimation);
            ObjectWithAnimation.PlayScriptableAnimationOpen();
        }
        ToolObject = GetComponent<IToolObject>();
        if (ToolObject!=null)
            SetToolObjectEvent?.Invoke(ToolObject);
    }
    public override void OnHoverIn(InteractHand interactHand)
    {
        if (!NonAOS)
            HelperTextEvent?.Invoke(HelperName);
        EnableHighlight(true);
    }
    public override void OnHoverOut(InteractHand interactHand)
    {
        if (!NonAOS)
            HelperTextEvent?.Invoke(null);
        EnableHighlight(false);
    }
    public override void EnableObject(bool value)
    {
        EnableHighlight(false);
        if (GetComponent<Collider>() != null)
            GetComponent<Collider>().enabled = value;
        if (GetComponent<SpriteRenderer>() != null)
            GetComponent<SpriteRenderer>().enabled = value;
        if (GetComponent<Image>() != null)
            GetComponent<Image>().enabled = value;
    }
    public virtual void SetHelperName(string value) => HelperName = value;
    protected virtual void EnableHighlight(bool value)
    {
        foreach (var visual in _highlights)
        {
            foreach (var mesh in visual.GetComponentsInChildren<Renderer>())
            {
                if (mesh == null)
                    return;
                if (value)
                {
                    mesh.material.EnableKeyword("_EMISSION");
                    mesh.material.SetColor("_EmissionColor", new Color(EmissionValue, EmissionValue, EmissionValue));
                }
                else
                    mesh.material.SetColor("_EmissionColor", Color.black);
            }
        }
    }
}
