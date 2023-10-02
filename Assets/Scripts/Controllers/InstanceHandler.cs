using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanceHandler : MonoBehaviour
{
    public static InstanceHandler Instance;
    public SceneAosObject SceneAosObject { get; set; }
    private List<ObjectWithAnimation> _animationObjectList = new List<ObjectWithAnimation>();

    [SerializeField] private AOSColliderActivator _aosColliderActivator;
    [SerializeField] private BackButtonsActivator _backButtonsActivator;
    [SerializeField] private LocationController _locationController;
    [SerializeField] private Teleporter _teleporter;
    [SerializeField] private MovingButtonsController _movinButtonsController;
    [SerializeField] private HelpTextController _helpTextController;
    [SerializeField] private CanvasChanger _canvasChanger;
    [SerializeField] private TimerView _timerView;
    [SerializeField] private MainMenuCanvas _mainMenuCanvas;
    [SerializeField] private PhoneCanvas _phoneCanvas;

    public AOSColliderActivator AOSColliderActivator => _aosColliderActivator;
    public MovingButtonsController MovingButtonsController => _movinButtonsController;
    public HelpTextController HelpTextController => _helpTextController;
    public LocationController LocationController => _locationController;
    public CanvasChanger CanvasChanger => _canvasChanger;
    public TimerView TimerView => _timerView;
    public MainMenuCanvas MainMenuCanvas => _mainMenuCanvas;
    public Teleporter Teleporter => _teleporter;
    public BackButtonsActivator BackButtonsActivator => _backButtonsActivator;
    public PhoneCanvas PhoneCanvas => _phoneCanvas;
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
