using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseScreen : MonoBehaviour
{
    [SerializeField] protected GameObject Screen;
    public bool ActiveSelf => Screen.activeSelf;
    public abstract void ActivateScreen(bool active);
}
