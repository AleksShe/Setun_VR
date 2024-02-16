using UnityEngine;

public abstract class BaseInteractScreen : MonoBehaviour
{
    protected Timer Timer = new Timer();
    public abstract void SetTimerText(string timerText);
    public abstract void SetLocationText(string locationText);
    public abstract void SetHelperText(string helperText);
    public abstract void SetReactionText(string helperText);
    public abstract void EnableHelperObject(bool active);
    public abstract void EnableReactionObject(bool active);
    public abstract void EnableLocationObject(bool active);
    public abstract void EnableTimerObject(bool active);
    public abstract void EnableActivateActionObject(SceneActionState state);
    public abstract void DisableAllActionObjects();
    public abstract void EnableInteractIcons(bool active);
    public abstract void SetHelperTextPosition(VectorHolder newPos);
    public void EnableAllHelperObjects(bool active)
    {
        EnableActivateActionObject(SceneActionState.None);
        EnableInteractIcons(active);
    }
}
