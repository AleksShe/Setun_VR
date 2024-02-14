using UnityEngine;

public class DesktopActionObject : BaseActionObject
{
    [SerializeField] protected GameObject Canvas;
    [SerializeField] private DesktopActionObject _objectToHide;
    public override void Activate()
    {
        base.Activate();
        if (!CanActivate)
            return;
        if (!Canvas.activeSelf)
        {
            Canvas.SetActive(true);
            if(_objectToHide!=null)
            _objectToHide.Deactivate();
        }
        else
            Deactivate();
    }

    public override void Deactivate()
    {
        base.Deactivate();
        Canvas.SetActive(false);
    }
}
