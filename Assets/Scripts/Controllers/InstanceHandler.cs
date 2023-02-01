using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class InstanceHandler : MonoBehaviour
{
    public static InstanceHandler Instance;
    public SceneAosObject SceneAosObject { get; set; }

    [SerializeField] private AOSColliderActivator _aosColliderActivator;
    [SerializeField] private BackButtonsActivator _backButtonsActivator;
    [SerializeField] private MeasureButtonsActivator _measureButtonsActivator;
    [SerializeField] private RadioButtonsContainer _radioButtonsContainer;
    [SerializeField] private LocationController _locationController;
    [SerializeField] private Teleporter _teleporter;
    [SerializeField] private MovingButtonsController _movinButtonsController;
    [SerializeField] private MovingTextWindow _objectsInfoWindow;
    [SerializeField] private MovingTextWindow _reactionInfoWindow;
    [SerializeField] private CanvasChanger _canvasChanger;
    [SerializeField] private TimerView _timerView;
    [SerializeField] private MainMenuCanvas _mainMenuCanvas;
    [SerializeField] private Diet _diet;
    [SerializeField] private ShupPositionChanger _shupPositionChanger;

    public AOSColliderActivator AOSColliderActivator => _aosColliderActivator;
    public MovingButtonsController MovingButtonsController => _movinButtonsController;
    public MovingTextWindow ObjectsInfoWindow => _objectsInfoWindow;
    public MovingTextWindow ReactionInfoWindow => _reactionInfoWindow;
    public LocationController LocationController => _locationController;
    public MeasureButtonsActivator MeasureButtonsActivator => _measureButtonsActivator;
    public CanvasChanger CanvasChanger => _canvasChanger;
    public TimerView TimerView => _timerView;
    public MainMenuCanvas MainMenuCanvas => _mainMenuCanvas;
    public RadioButtonsContainer RadioButtonsContainer => _radioButtonsContainer;
    public Diet Diet => _diet;
    public Teleporter Teleporter => _teleporter;
    public BackButtonsActivator BackButtonsActivator => _backButtonsActivator;
    public ShupPositionChanger ShupPositionChanger => _shupPositionChanger;
    private void Awake()
    {
        if(Instance==null)
            Instance = this;
    }
}
