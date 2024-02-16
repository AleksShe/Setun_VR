using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PlayerState
{
    Walk,
    Look
}

public class SceneObjectsHolder : MonoBehaviour
{
    public static SceneObjectsHolder Instance;
    [SerializeField] private API _api;
    [SerializeField] private LocationController _locationController;
    [SerializeField] private ModeController _modeController;
    [SerializeField] private MouseRayCastHandler _mouseRayCastHandler;
    [SerializeField] private CanvasParentChanger _canvasParentChanger;
    [SerializeField] private MoveUiButtonsHolder _moveUiButtonsHolder;
    [SerializeField] private CursorManager _cursor;
    [SerializeField] private EscActionObject _actionObject;
    [SerializeField] private DoorSoundPlayer _doorSoundPlayer;

    public PlayerState CurrentState { get; set; }
    public IToolObject ToolObject { get; private set; }

    private List<BaseObject> _baseObjects = new List<BaseObject>();
    private List<PointObject> _aosPointObjects = new List<PointObject>();
    private List<BaseUIButton> _baseUiButtons = new List<BaseUIButton>();
    private List<ObjectWithAnimation> _objectsWithAnimations = new List<ObjectWithAnimation>();
    public SceneAosObject SceneAosObject { get; private set; }
    public ModeController ModeController => _modeController;
    public DoorSoundPlayer DoorSoundPlayer => _doorSoundPlayer;
    public MouseRayCastHandler MouseRayCastHandler => _mouseRayCastHandler;
    public LocationController LocationTextController => _locationController;
    private bool _reaction;
    public bool Reaction => _reaction;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    private void Start()
    {
        BackActionObject.BackEvent += OnBackUiButtonClick;
        if (_modeController.DesktopMode)
            _mouseRayCastHandler.MousePosHoverEvent += OnChangeHelperOnHoverEvent;
        _mouseRayCastHandler.MousePosClickEvent += OnChangeReactionPositionEvent;
        _actionObject.EscActionEvent += OnEscButtonAction;
        ReactionUIButton.ActionWithObjectEvent += OnPlayActionAnimation;
    }

    public void AddSceneObject(BaseObject obj)
    {
        if (obj is PlaceObject)
        {
            var placeObject = (PlaceObject)obj;
            placeObject.CameraChangedEvent += OnChangeCanvasPerentCamera;
            placeObject.SetBackLocationNameEvent += OnSetBackLocation;
            placeObject.SetSideMovingObjectEvent += OnSetSideMovingObject;
        }
        if (obj is SceneObject)
        {
            var sceneObject = (SceneObject)obj;
            sceneObject.HelperTextEvent += OnShowHelperText;
            sceneObject.AddAnimationObjectEvent += OnAddAnimationObject;
            sceneObject.SetToolObjectEvent += OnSetToolObject;
        }
        if(obj is ObjectWithActions)
        {
            var sceneObject = (ObjectWithActions)obj;
            sceneObject.AddToolObjectEvent += OnSetCurrentTool;
        }
        obj.AddSceneObjectEvent += OnInitCurrentSceneObject;
        _baseObjects.Add(obj);
    }

    public void AddBaseUIButton(BaseUIButton obj)
    {
        if (obj is INextButton)
        {
            var nextButton = (INextButton)obj;
            nextButton.NextButtonPressedEvent += OnNextButtonClicked;
        }
        if (obj is MoveUiButton)
        {
            var moveButton = (MoveUiButton)obj;
            moveButton.PointerEnterEvent += OnHideAllReaction;
        }
        else if (obj is OkUiButton)
        {
            var okButton = (OkUiButton)obj;
            okButton.OkClickEvent += OnHideReactionWindow;
        }
        obj.HoverUiEvent += OnHandleHoverMouse;
        _baseUiButtons.Add(obj);
    }
    private void OnNextButtonClicked(string actionName)
    {
        _api.OnInvokeNavAction(actionName);
    }
    public void ActivatePoints(string pointName, string text)
    {
        foreach (var pointObj in _aosPointObjects)
        {
            if (pointObj.GetAOSName() == pointName)
            {
                pointObj.EnableObject(true);
                pointObj.SetPointText(text);
            }
        }
    }
    private void OnSetToolObject(IToolObject toolObject) => ToolObject = toolObject;
    private void OnPlayActionAnimation(ButtonActionName name)
    {
       switch (name)
        {
            case ButtonActionName.tool:

                ToolObject.PlayToolAnimation();
                    break;
        }
    }
    public void ActivateBaseObjects(string objectId, string objectName, string timeText)
    {
        if (timeText == "" || timeText == "0")
            timeText = objectName;
        else
            timeText = $"{objectName} \nВремя перехода:{timeText}";
        foreach (var item in _baseObjects)
        {
            if (item.GetAOSName() == objectId)
            {
                item.EnableObject(true);
                if (item is SceneObject)
                {
                    var sceneObject = (SceneObject)item;
                    sceneObject.SetHelperName(timeText);
                }
            }
        }
    }
    private void OnChangeCanvasPerentCamera(Camera camera)
    {
        _canvasParentChanger.ChangeCameraParent(camera);
        _mouseRayCastHandler.CanHover = true;
        _mouseRayCastHandler.CanInteract = true;
    }
    private void OnAddAnimationObject(ObjectWithAnimation objectWithAnimation)
    {
        _objectsWithAnimations.Add(objectWithAnimation);
    }
    private void OnSetBackLocation(string location)
    {
        _locationController.BackLocation = location;
    }
    private void OnSetSideMovingObject(BaseSideMovingObject obj)
    {
        _moveUiButtonsHolder.SetSideMovingObject(obj);
    }
    private void OnShowHelperText(string text)
    {
        _modeController.CurrentInteractScreen.SetHelperText(text);
    }
    private void OnInitCurrentSceneObject(SceneAosObject sceneAosObject)
    {
        SceneAosObject = sceneAosObject;
    }
    private void OnSetCurrentTool(IToolObject tool)
    {

    }
    //public void ActivateArmUIpoints(string pointName, string actiontext)
    //{
    //    foreach (var pointObj in _baseUiButtons)
    //    {
    //        if (pointObj.GetAOSName() == pointName)
    //        {
    //            pointObj.EnableUIButton(true);
    //            pointObj.SetSceneAosEventText(actiontext);
    //        }
    //    }
    //}
    private void OnHideReactionWindow()
    {
        _modeController.CurrentInteractScreen.EnableReactionObject(false);
        _mouseRayCastHandler.CanHover = true;
        _mouseRayCastHandler.CanInteract = true;
        _reaction = false;
        if (CurrentState == PlayerState.Walk)
            _cursor.EnableCursor(false);
    }
    private void OnHandleHoverMouse(bool active)
    {
        _mouseRayCastHandler.CanHover = !active;
    }
    private void OnHideAllReaction()
    {
        _modeController.BaseReactionButtonsHandler.HideAllReactions();
        _mouseRayCastHandler.CanHover = true;
        _mouseRayCastHandler.CanInteract = true;
    }
    private void OnDeactivateAllColliders()
    {
        foreach (var sceneObject in _baseObjects)
            sceneObject.EnableObject(false);
    }
    public void DeactivateAllArmUIPoints()
    {
        foreach (var armButton in _baseUiButtons)
            armButton.EnableUIButton(false);
    }
    private void OnDeactivateAllPoints()
    {
        foreach (var point in _aosPointObjects)
            point.EnableObject(false);
    }
    private void ResetAllAnimationObjects()
    {
        foreach (var item in _objectsWithAnimations)
        {
            item.PlayScriptableAnimationClose();
        }
        _objectsWithAnimations.Clear();
    }
    private void OnEscButtonAction()
    {
        if (_modeController.CurrentMenuController.InMenu)
            _modeController.CurrentMenuController.TeleportToGame();
        else
            _modeController.CurrentMenuController.TeleportToMenu();
    }
    public void DeactivateAllSceneObjects()
    {
        foreach (var sceneObj in _baseObjects)
            sceneObj.EnableObject(false);
    }
    private void OnBackUiButtonClick()
    {
        _canvasParentChanger.RevertCamera();
        _locationController.SetPreviousLocation();
        _moveUiButtonsHolder.SetSideMovingObject(null);
        _modeController.CurrentInteractScreen.DisableAllActionObjects();
        ModeController.BaseReactionButtonsHandler.HideAllReactions();
        ResetAllAnimationObjects();
        OnHideReactionWindow();
    }
    private void OnChangeHelperOnHoverEvent(VectorHolder holder)
    {
        _modeController.CurrentInteractScreen.SetHelperTextPosition(holder);
    }
    private void OnChangeReactionPositionEvent(VectorHolder holder)
    {
        if (holder == null)
        {
            _modeController.BaseReactionButtonsHandler.HideAllReactions();
        }
        else
        {
            _modeController.BaseReactionButtonsHandler.SetButtonSpawnPos(holder.Position);
            _mouseRayCastHandler.CanHover = false;
        }
    }
    public void SetReaction(string text)
    {
        Debug.Log(text + "     SetReaction");
        ModeController.CurrentInteractScreen.EnableReactionObject(true);
        ModeController.CurrentInteractScreen.SetReactionText(text);
        ModeController.CurrentInteractScreen.EnableHelperObject(false);
        ModeController.BaseReactionButtonsHandler.HideAllReactions();
        Instance.MouseRayCastHandler.CanInteract = false;
        _reaction = true;
        if (CurrentState == PlayerState.Walk)
            _cursor.EnableCursor(true);
    }
    public void ActivateArmUIpoints(string id,string name)
    {

    }
}
