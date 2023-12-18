using AosSdk.Core.PlayerModule;
using System.Linq;
using UnityEngine;

public class DesktopCanvas : GameCanvasBase
{
 
    [SerializeField] private PlayerCameraDisabler _playerCameraDisabler;
    [SerializeField] private DesktopCanvasObject[] _desktopCanvases;
    [SerializeField] private EscButton _escButton;
    [SerializeField] private DesktopCanvasObjectsHolder _textHolder;
    [SerializeField] private DesktopCanvasObjectsHolder _buttonsHolder;
    [SerializeField] private CameraFlash _cameraFlash;
    [SerializeField] private GameObject _timer;
    [SerializeField] private GameObject _location;

    private bool _canSwitch = true;

    private const string START = "start";
    private void Start()
    {
        NextButton.NextButtonPressedEvent += OnStartGame;
        _escButton.EscClickEvent += OnEscClick;
        BackFromMenuUIButton.BackButtonClickEvent += OnExitFromCanvas;
    }
    private void OnStartGame(string name)
    {
        if (name == START)
        {
            DisableAllCanvases();
            ShowCanvas(CanvasState.None);
            _cameraFlash.CameraFlashStart();
            EnableInteractImages(true);
        }
    }
    private void OnEscClick()
    {
        if (CurrentState == CanvasState.Arm || CurrentState == CanvasState.Phone)
            return;
        if (CurrentState != CanvasState.Start && CurrentState != CanvasState.Menu)
        {
            ShowCanvas(CanvasState.Menu);
            InstanceHandler.Instance.API.OnMenuInvoke();
        }
        else ShowCanvas(CanvasState.None);
        _cameraFlash.CameraFlashStart();
    }
    private void OnExitFromCanvas()
    {
        ShowCanvas(CanvasState.None);
        _cameraFlash.CameraFlashStart();
    }

    public override void ShowCanvas(CanvasState state)
    {
        if (!_canSwitch)
            return;
        SwitchCamera(state);
        var canvasToShow = _desktopCanvases.FirstOrDefault(c => state == c.CurrentState);
        if (canvasToShow != null)
        {
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
    public void SwitchCamera(CanvasState state)
    {
        if (state == CanvasState.None)
            _playerCameraDisabler.EnableDesktopCamera(true);
        else
            _playerCameraDisabler.EnableDesktopCamera(false);
        if (state == CanvasState.Arm)
            EnableInteractImages(false);
        else if(state !=CanvasState.Start)
            EnableInteractImages(true);
    }
    protected override void OnShowLastScreen()
    {
        ShowCanvas(CanvasState.Last);
    }
    protected override void OnShowResultLastScreen()
    {
        ShowCanvas(CanvasState.Last);
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
    private void EnableInteractImages(bool active)
    {
        _timer.SetActive(active);
        _location.SetActive(active);
    }
}
