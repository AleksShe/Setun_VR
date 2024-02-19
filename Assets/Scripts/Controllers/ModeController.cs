using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeController : MonoBehaviour
{
    [SerializeField] private AosSDKSettings _aosSettings;
    [SerializeField] private GameObject _desktopPlayer;
    [SerializeField] private GameObject _vrPlayer;
    [Space]
    [SerializeField] private BaseStartScreenView _desktopStartScreenView;
    [SerializeField] private BaseStartScreenView _vrStartScreenView;
    [Space]
    [SerializeField] private BaseMenuScreen _deskMenuScreen;
    [SerializeField] private BaseMenuScreen _vrMenuScreen;
    [Space]
    [SerializeField] private BaseInteractScreen _desktopInteractScreen;
    [SerializeField] private BaseInteractScreen _vrInteractScreen;
    [Space]
    [SerializeField] private BaseMenuController _desktopMenuController;
    [SerializeField] private BaseMenuController _vrMenuController;
    [Space]
    [SerializeField] private BaseReactionButtonsHandler _desktopReactionButtonsHandler;
    [SerializeField] private BaseReactionButtonsHandler _vrReactionButtonsHandler;
    [Space]
    [SerializeField] private BasePhoneScreen _desktopPhoneScreen;
    [SerializeField] private BasePhoneScreen _vrPhoneScreen;
    [Space]
    [SerializeField] private BaseScreen _desktopArmScreen;
    [SerializeField] private BaseScreen _vrArmScreen;
    public BaseStartScreenView CurrentStartScreen { get; private set; }
    public BaseInteractScreen CurrentInteractScreen { get; private set; }
    public BaseMenuScreen CurrentMenuScreen { get; private set; }
    public BaseMenuController CurrentMenuController { get; private set; }
    public BaseReactionButtonsHandler BaseReactionButtonsHandler { get; private set; }
    public BasePhoneScreen CurrentPhoneScreen { get; private set; }
    public BaseScreen CurrentArmScreen { get; private set; }
    private LaunchMode _currentMode;
    public bool DesktopMode => _currentMode == LaunchMode.Desktop;

    private void Start()
    {
        _currentMode = _aosSettings.launchMode;
        EnableObjectsByMode();
    }
    public Transform GetPlayerTransform()
    {
        if (_currentMode == LaunchMode.Vr)
            return _vrPlayer.transform;
        else if (_currentMode == LaunchMode.Desktop)
            return _desktopPlayer.transform;
        return null;
    }

    private void EnableObjectsByMode()
    {
        if (DesktopMode)
        {
            CurrentStartScreen = _desktopStartScreenView;
            CurrentInteractScreen = _desktopInteractScreen;
            CurrentMenuScreen = _deskMenuScreen;
            CurrentMenuController = _desktopMenuController;
            BaseReactionButtonsHandler = _desktopReactionButtonsHandler;
            CurrentPhoneScreen = _desktopPhoneScreen;
            CurrentArmScreen = _desktopArmScreen;
        }
        else
        {
            CurrentStartScreen = _vrStartScreenView;
            CurrentInteractScreen = _vrInteractScreen;
            CurrentMenuScreen = _vrMenuScreen;
            CurrentMenuController = _vrMenuController;
            BaseReactionButtonsHandler = _vrReactionButtonsHandler;
            CurrentPhoneScreen = _vrPhoneScreen;
            CurrentArmScreen = _vrArmScreen;
        }
    }

}
