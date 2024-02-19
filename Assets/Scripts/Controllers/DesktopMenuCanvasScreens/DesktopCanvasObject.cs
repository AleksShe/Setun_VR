using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CanvasState
{
    None,
    Start,
    Menu,
    Arm,
    Phone,
    Last,
    Other,
    MainMenu,
    Result
}

public class DesktopCanvasObject : MonoBehaviour
{
    [SerializeField] private CanvasState _currentState;
    public CanvasState CurrentState => _currentState;
}
