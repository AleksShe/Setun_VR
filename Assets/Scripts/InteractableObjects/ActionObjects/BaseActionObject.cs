using System;
using UnityEngine;
public enum SceneActionState
{
    None,
    Back
}

public class BaseActionObject : MonoBehaviour
{
    protected bool CanActivate { get; set; } = false;
    public SceneActionState SceneActionState => CurrentState;
    [SerializeField] protected SceneActionState CurrentState;
    [SerializeField] protected BaseActionButton BaseActionButton;
    [SerializeField] protected UIButtonWithColorChanger BaseUIButton;

    public UIButtonWithColorChanger ColorButton => BaseUIButton;
    protected virtual void Start()
    {
        BaseActionButton.ActionButtonEvent += Activate;
        BaseUIButton.ClickButtonEvent += Activate;
        if (CurrentState == SceneActionState.None)
            CanActivate = true;
    }
    public void Enable()
    {
        CanActivate = true;
        BaseUIButton.BaseUIColorChanger.CanChangeState = true;
        BaseUIButton.BaseUIColorChanger.ActivateState();
        BaseUIButton.EnableUIButton(true);
    }
    public virtual void Activate()
    {
        if (!CanActivate)
            return;
        //SceneObjectsHolder.Instance.ActionButtonsHolder.InVokeOnClick(CurrentState);
        BaseUIButton.BaseUIColorChanger.EnabledState();
        BaseUIButton.BaseUIColorChanger.CanChangeState = false;
    }
    public virtual void Deactivate()
    {
        BaseUIButton.BaseUIColorChanger.CanChangeState = true;
        BaseUIButton.BaseUIColorChanger.ActivateState();
    }
    public virtual void Disable()
    {
        Deactivate();
        CanActivate = false;
        BaseUIButton.BaseUIColorChanger.DeactivateState();
        BaseUIButton.EnableUIButton(false);
        BaseUIButton.BaseUIColorChanger.CanChangeState = false;
    }
}
