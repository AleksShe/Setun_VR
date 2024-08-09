using System;

public class BackActionObject : BaseActionObject
{
    public static Action BackEvent;
    public override void Activate()
    {
        if (SceneObjectsHolder.Instance.ModeController.CurrentMenuController.InMenu)
            return;

        base.Activate();
        if (!CanActivate)
            return;
        BackEvent?.Invoke();
        BaseUIButton.BaseUIColorChanger.DeactivateState();
    }
}
