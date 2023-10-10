using AosSdk.Core.PlayerModule;
using System.Linq;
using UnityEngine;

public class DesktopCanvas : GameCanvasBase
{
    [SerializeField] private GameObject _menuDesktopCamera;
    [SerializeField] private PlayerCameraDisabler _playerCameraDisabler;
    [SerializeField] private DesktopCanvasObject[] _desktopCanvases;
    [SerializeField] private EscButton _escButton;
    [SerializeField] private DesktopCanvasObjectsHolder _textHolder;
    [SerializeField] private DesktopCanvasObjectsHolder _buttonsHolder;

    private bool _canSwitch = true;

    private const string START = "start";
    private void Start()
    {
        NextButton.NextButtonPressedEvent += OnStartGame;
        _escButton.EscClickEvent += OnEscClick;
        BackFromMenuUIButton.BackButtonClickEvent += OnEscClick;
    }
    private void OnStartGame(string name)
    {
        if (name == START)
        {
            DisableAllCanvases();
            ShowCanvas(CanvasState.None);
        }
    }
    private void OnEscClick()
    {
        if (CurrentState != CanvasState.Start && CurrentState != CanvasState.Menu && CurrentState != CanvasState.Phone && CurrentState != CanvasState.Arm)
        {
            ShowCanvas(CanvasState.Menu);
            InstanceHandler.Instance.API.OnMenuInvoke();
        }
        else ShowCanvas(CanvasState.None);
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
        {
            Cursor.lockState = CursorLockMode.Locked;
            _menuDesktopCamera.SetActive(false);
            Player.Instance.CanMove = true;
            _playerCameraDisabler.EnableDesktopCamera(true);
            return;
        }
        Cursor.lockState = CursorLockMode.None;
        _menuDesktopCamera.SetActive(true);
        _playerCameraDisabler.EnableDesktopCamera(false);
        Player.Instance.CanMove = false;
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
        _textHolder.AddItem(name,role);
    }
    public override void AddTextObjectUiButton(string id, string name)
    {
        _buttonsHolder.AddItem(id, name);
    }
}
