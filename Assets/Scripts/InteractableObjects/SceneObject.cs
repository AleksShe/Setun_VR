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
    [SerializeField] private GameObject[] _highlights;
    protected string HelperName;
    protected void Start()
    {
        if (!NonAOS)
        {
            EnableObject(false);
            InstanceHandler.Instance.AOSColliderActivator.AddSceneObject(this);
        }
    }
    public override void OnHoverIn(InteractHand interactHand)
    {
        if (HelperPos != null)
            InstanceHandler.Instance.HelpTextController.ShowHelperText(HelperPos, HelperName);
        EnableHighlight(true);
    }
    public override void OnHoverOut(InteractHand interactHand)
    {
        InstanceHandler.Instance.HelpTextController.HideHelperText();
        EnableHighlight(false);
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
    public virtual void SetHelperName(string value) => HelperName = value;
    protected void EnableHighlight(bool value)
    {
        if (_highlights == null )
            return;
        foreach (var hl in _highlights)
            hl.SetActive(value);
    }
}
