using AosSdk.Core.PlayerModule;
using System.Linq;
using UnityEngine;

public class DesktopCanvas : GameCanvasBase
{
    [SerializeField] private DesktopCanvasObject[] _desktopCanvases;
    [SerializeField] private DesktopPhoneScreen _textHolder;
    [SerializeField] private DesktopPhoneScreen _buttonsHolder;

    [SerializeField] private GameObject _messagePanel;

    [HideInInspector] public bool CanTeleport = true;

    private bool _canSwitch = true;
    private void Start()
    {
        Player.Instance.CanMove = false;
        CanTeleport = false;
    }

    public override void ShowCanvas(CanvasState state)
    {
        if (!_canSwitch)
            return;
        var canvasToShow = _desktopCanvases.FirstOrDefault(c => state == c.CurrentState);
      
        if (canvasToShow != null)
        {
            Debug.Log(canvasToShow.ToString());
            DisableAllCanvases();
            canvasToShow.gameObject.SetActive(true);
            if(state == CanvasState.Menu)
            {
                var childCanvas = _desktopCanvases.FirstOrDefault(c => c.CurrentState == CanvasState.MainMenu);
                if(childCanvas!=null)
                    childCanvas.gameObject.SetActive(true);
            }
             
        }
        CurrentState = state;
    }
    private void DisableAllCanvases()
    {
        foreach (var canvas in _desktopCanvases)
            canvas.gameObject.SetActive(false);
    }
    protected override void OnShowLastScreen()
    {
        ShowCanvas(CanvasState.Menu);
        _messagePanel.SetActive(true);
    }
    protected override void OnShowResultLastScreen()
    {
        Debug.Log("IN RESULT SCREEN");
        ShowCanvas(CanvasState.Result);
        _canSwitch = false;
        CanvasText.ShowExitButton();
    }
    public override void AddTextObjectUi(string name, DialogRole role)
    {
        _textHolder.AddItem(name, role);
    }
    public override void AddTextObjectUiButton(string id, string name)
    {
        _buttonsHolder.AddItem(id, name);
    }

}
