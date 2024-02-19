using UnityEngine;
public class DesktopMenuController : BaseMenuController
{
    [SerializeField] private CameraFlash _cameraFlash;
    [SerializeField] private CursorManager _cursorManager;

    public override void TeleportToMenu()
    {
        base.TeleportToMenu();
        if (!CanTeleport)
        {
            return;
        }
        _cameraFlash.CameraFlashStart();
        _cursorManager.EnableCursor(true);
        if(SceneObjectsHolder.Instance.CurrentState == PlayerState.Look)
            SceneObjectsHolder.Instance.ModeController.CurrentInteractScreen.EnableInteractIcons(false);
    }
    public override void TeleportToGame()
    {
        base.TeleportToGame();
        if (!CanTeleport)
        {
            return;
        }
        if (SceneObjectsHolder.Instance.CurrentState == PlayerState.Walk && !SceneObjectsHolder.Instance.Reaction)
        _cursorManager.EnableCursor(false);
        else if(SceneObjectsHolder.Instance.CurrentState == PlayerState.Look)
            SceneObjectsHolder.Instance.ModeController.CurrentInteractScreen.EnableInteractIcons(true);
        _cameraFlash.CameraFlashStart();
    }
    public override void TeleportByGameTimer()
    {
        base.TeleportByGameTimer();
        _cursorManager.EnableCursor(true);
        _cameraFlash.CameraFlashStart();
    }
}
