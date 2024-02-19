using UnityEngine;

public abstract class BaseMenuController : MonoBehaviour
{
    [SerializeField] protected API Api;
    [SerializeField] protected ModeController ModeController;
    public bool CanTeleport { get; set; } = false;
    public bool InMenu { get; private set; }
    public virtual void TeleportToMenu()
    {
        if (InMenu || !CanTeleport)
            return;
        InMenu = true;
        Api.OnMenuInvoke();
        ModeController.CurrentInteractScreen.EnableAllHelperObjects(false);
        ModeController.CurrentMenuScreen.ShowMenuScreen(true);
    }
    public virtual void TeleportToGame()
    {
        if (!InMenu||!CanTeleport)
            return;
        //var location = SceneObjectsHolder.Instance.LocationTextController.CurrentLocation();
        //Api.InvokeEndTween(location);
        InMenu = false;
        ModeController.CurrentInteractScreen.EnableAllHelperObjects(true);
        ModeController.CurrentMenuScreen.ShowMenuScreen(false);
    }
    public virtual void TeleportByGameTimer()
    {
        InMenu = true;
        CanTeleport = false;
    }
}
