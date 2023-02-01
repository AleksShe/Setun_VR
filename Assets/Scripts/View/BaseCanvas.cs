using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCanvas : MonoBehaviour
{
    [SerializeField] private string _canvasName;
    private Canvas _canvas;
    public string CanvasName => _canvasName;
    private void Start()
    {
        _canvas = GetComponent<Canvas>();
    }
    public void EnableCanvas(bool value)
    {
        _canvas.enabled = value;
    }
}
