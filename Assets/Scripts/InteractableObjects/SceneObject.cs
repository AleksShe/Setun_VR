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
    [SerializeField] protected Renderer[] Meshes;
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
        EnableMeshes(true);
    }
    public override void OnHoverOut(InteractHand interactHand)
    {
        InstanceHandler.Instance.HelpTextController.HideHelperText();
        EnableMeshes(false);
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
    protected void EnableMeshes(bool value)
    {
        if (Meshes != null)
            foreach (var mesh in Meshes)
            {
                if (mesh != null)
                {
                    var materials = mesh.materials;
                    if (value)
                        foreach (var item in materials)
                        {
                            item.color *= 2;
                        }
                    else
                        foreach (var item in materials)
                        {
                            item.color /= 2;
                        }
                }
            }
    }
}
