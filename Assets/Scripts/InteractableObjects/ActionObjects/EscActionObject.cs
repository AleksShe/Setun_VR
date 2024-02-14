using System;

public class EscActionObject : BaseActionObject
{
    public Action EscActionEvent;
    public override void Activate()
    {
        EscActionEvent?.Invoke();
    }
}
