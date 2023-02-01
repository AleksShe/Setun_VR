using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class CanvasChanger : MonoBehaviour
{
    [SerializeField] private StartCanvas _startView;
    [SerializeField] private MainMenuCanvas _mainMenuCanvas;
    [SerializeField] private BaseCanvas[] _baseCanvases;
    [SerializeField] private NextButton _nextButton;
    [SerializeField] private Teleporter _teleporter;

    private void OnEnable()
    {
        _nextButton.OnNextButtonPressed += OnHideStartScreen;
        _teleporter.OnTeleportEnd += OnEnableMenuScreen;
    }
    private void OnDisable()
    {
        _nextButton.OnNextButtonPressed -= OnHideStartScreen;
        _teleporter.OnTeleportEnd -= OnEnableMenuScreen;
    }
    public void EnableStartScreen(string headerText, string commentText, string buttonText, NextButtonState state)
    {
        EnableCanvasByname("start");
        _startView.EnableStartScreen(headerText, commentText, buttonText);
        _nextButton.CurrentState = state;
    }
    private void OnHideStartScreen(string value)
    {
        if (value != "start")
            return;
        EnableCanvasByname(null);
    }
    private void OnEnableMenuScreen(string value)
    {
        if (value != "menu")
            return;
            _mainMenuCanvas.EnableCanvas(true);   
    }
    private void EnableCanvasByname(string value)
    {
        foreach (var canvas in _baseCanvases)
        {
            canvas.EnableCanvas(false);
        }
        var canvasToShow = _baseCanvases.FirstOrDefault(c => c.CanvasName == value);
        if(canvasToShow!=null)
            canvasToShow.EnableCanvas(true);
    }
}
