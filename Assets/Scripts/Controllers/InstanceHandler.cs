using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlayerState
{
    Walk,
    Look
}

public class InstanceHandler : MonoBehaviour
{
    public static InstanceHandler Instance;
    public SceneAosObject SceneAosObject { get; set; }
    private List<ObjectWithAnimation> _animationObjectList = new List<ObjectWithAnimation>();

    [SerializeField] private AOSObjectsActivator _aosColliderActivator;
    [SerializeField] private BackButtonsActivator _backButtonsActivator;
    [SerializeField] private LocationController _locationController;
    [SerializeField] private Teleporter _teleporter;
    [SerializeField] private MovingButtonsController _movinButtonsController;
    [SerializeField] private HelpTextController _helpTextController;
    [SerializeField] private CanvasMode _canvasMode;
    [SerializeField] private TimerTextHolder _timerView;
    [SerializeField] private MainMenuCanvas _mainMenuCanvas;
    [SerializeField] private ModeController _modeController;
    [SerializeField] private DoorSoundPlayer _doorSoundPlayer;
    [SerializeField] private BackTriggersHolder _backTriggersHolder;
    [SerializeField] private InstantiateResultButton _instResultButton;
    [SerializeField] private API _api;
    [SerializeField] private MouseRayCastHandler _mouseRayCastHandler;
    [SerializeField] private CanvasParentChanger _canvasParentChanger;
    [SerializeField] private MoveUiButtonsHolder _moveUiButtonsHolder;

    public AOSObjectsActivator AOSColliderActivator => _aosColliderActivator;
    public MovingButtonsController MovingButtonsController => _movinButtonsController;
    public HelpTextController HelpTextController => _helpTextController;
    public LocationController LocationController => _locationController;
    public CanvasMode CanvasMode => _canvasMode;
    public TimerTextHolder TimerView => _timerView;
    public MainMenuCanvas MainMenuCanvas => _mainMenuCanvas;
    public Teleporter Teleporter => _teleporter;
    public BackButtonsActivator BackButtonsActivator => _backButtonsActivator;
    public ModeController ModeController => _modeController;
    public DoorSoundPlayer DoorSoundPlayer => _doorSoundPlayer;
    public BackTriggersHolder BackTriggersHolder => _backTriggersHolder;
    public API API => _api;
    public MouseRayCastHandler MouseRayCastHandler => _mouseRayCastHandler;
    public CanvasParentChanger CanvasParentChanger => _canvasParentChanger;
    public InstantiateResultButton InstResultButton => _instResultButton;
    public MoveUiButtonsHolder MoveUiButtonsHolder => _moveUiButtonsHolder;
    public PlayerState CurrentState { get; set; }
    public void AddAnimationObjectToList(ObjectWithAnimation obj)
    {
        _animationObjectList.Add(obj);
    }
    public void PlayCloseAnimationForAllObjects()
    {
        foreach (var item in _animationObjectList)
        {
            item.PlayScriptableAnimationClose();
        }
        _animationObjectList.Clear();
    }
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
}
