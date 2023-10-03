using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopCanvasObject : MonoBehaviour
{
    [SerializeField] private CanvasState _currentState;
    public CanvasState CurrentState => _currentState;
}
