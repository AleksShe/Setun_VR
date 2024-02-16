using AosSdk.Core.PlayerModule.Pointer;
using System;

public class ObjectWithActions : SceneObject
{
    protected ToolObject ToolObject;
    public Action<ToolObject> AddToolObjectEvent;
    public override void OnClicked(InteractHand interactHand)
    {
        base.OnClicked(interactHand);
        ToolObject = GetComponent<ToolObject>();
        if (ToolObject != null)
            AddToolObjectEvent?.Invoke(ToolObject);
    }
}
