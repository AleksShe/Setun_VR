using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class BaseUIColorChanger : MonoBehaviour
{
    public bool CanChangeState { get; set; } = true;
    public virtual void DeactivateState()
    {
    }
    public virtual void ActivateState()
    {
    }
    public virtual void EnabledState()
    {
    }
    public virtual void HoveredState()
    {
    }
}
