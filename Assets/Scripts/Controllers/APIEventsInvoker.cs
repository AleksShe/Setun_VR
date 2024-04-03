using AosSdk.Core.PlayerModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APIEventsInvoker : MonoBehaviour
{
    [SerializeField] private API _api;
    [SerializeField] private Teleporter _teleporter;
    [SerializeField] private ConnectionToClient _connectionChecker;
    [SerializeField] private LocationController _locationController;
    [SerializeField] private ModeController _modeController;

    private void OnEnable()
    {
        _connectionChecker.ConnectionReadyEvent += OnSetLocationAfterConnection;
        _api.ShowPlaceEvent += OnDeactivateColliders;
        _api.ReactionEvent += OnSetReaction;
        _api.SetTeleportLocationEvent += OnSetLocationToTeleport;
        _api.SetNewLocationTextEvent += OnSetLocationTextToLocationController;
        _api.SetLocationEvent += OnSetLocationToLocationController;
        _api.EnableMovingButtonEvent += OnEnableMovingButton;
        _api.SetTimerTextEvent += OnSetTimerText;
        _api.ActivateByNameEvent += OnActivateSceneObjectByName;
        _api.ActivatePointByNameEvent += OnActivateSceneArmPointByName;
        _api.StartUpdatePlaceEvent += OnDeactivateUiButtons;
        _api.SetMessageTextEvent += OnSetLastScreenText;
        _api.SetResultTextEvent += OnSetResultScreenText;
        _api.ShowExitTextEvent += OnSetExitText;
        _api.ShowMenuTextEvent += OnSetMenuText;
        _api.SetStartTextEvent += OnSetStartText;
        _api.PointEvent += OnActivatePointObjectByName;
        _api.DialogHeaderEvent += OnEnableDialogHeader;
        _api.DialogEvent += OnEnableDialog;
        _api.AddTextObjectUiButtonEvent += OnAddTextObjectUiButton;
        _api.AddTextObjectUiEvent += OnAddTextObjectUi;
        _api.ResultNameTextButtonEvent += OnInstanseResultButtons;
        _api.ResultNameTextButtonSingleEvent += OnInstanseResultSingleButtons;
        _api.ShowMenuButtonEvent += OnShowMenuButton;
    }

    private void OnDisable()
    {
        _connectionChecker.ConnectionReadyEvent -= OnSetLocationAfterConnection;
        _api.ShowPlaceEvent -= OnDeactivateColliders;
        _api.ReactionEvent -= OnSetReaction;
        _api.SetTeleportLocationEvent -= OnSetLocationToTeleport;
        _api.SetNewLocationTextEvent -= OnSetLocationTextToLocationController;
        _api.SetLocationEvent -= OnSetLocationToLocationController;
        _api.EnableMovingButtonEvent -= OnEnableMovingButton;
        _api.SetTimerTextEvent -= OnSetTimerText;
        _api.ActivateByNameEvent -= OnActivateSceneObjectByName;
        _api.ActivatePointByNameEvent -= OnActivateSceneArmPointByName;
        _api.StartUpdatePlaceEvent -= OnDeactivateUiButtons;
        _api.SetMessageTextEvent -= OnSetLastScreenText;
        _api.SetResultTextEvent -= OnSetResultScreenText;
        _api.ShowExitTextEvent -= OnSetExitText;
        _api.ShowMenuTextEvent -= OnSetMenuText;
        _api.SetStartTextEvent -= OnSetStartText;
        _api.PointEvent -= OnActivatePointObjectByName;
        _api.DialogHeaderEvent -= OnEnableDialogHeader;
        _api.DialogEvent -= OnEnableDialog;
        _api.AddTextObjectUiButtonEvent -= OnAddTextObjectUiButton;
        _api.AddTextObjectUiEvent -= OnAddTextObjectUi;
        _api.ResultNameTextButtonEvent -= OnInstanseResultButtons;
        _api.ResultNameTextButtonSingleEvent += OnInstanseResultSingleButtons;
        _api.ShowMenuButtonEvent -= OnShowMenuButton;
    }
    private void OnInstanseResultSingleButtons(string name, string penalty)
    {
        SceneObjectsHolder.Instance.InstantiateResultButton.InstantiateSingleButtons(name, penalty);
    }
    private void OnInstanseResultButtons(string name,string penalty,string resultText)
    {
        SceneObjectsHolder.Instance.InstantiateResultButton.InstantiateButtons(name, penalty,resultText);
    }
    private void OnDeactivateUiButtons()
    {
        SceneObjectsHolder.Instance.DeactivateAllArmUIPoints();
    }
    private void OnDeactivateColliders()
    {
        SceneObjectsHolder.Instance.DeactivateAllSceneObjects();
    }
    private void OnEnableDialog(string text)
    {
        _modeController.CurrentPhoneScreen.ActivatePhoneDialogScreen(true);
    }
    private void OnAddTextObjectUiButton(string id,string name)
    {
        _modeController.CurrentPhoneScreen.AddItem(id, name);
    }
    private void OnAddTextObjectUi(string text,DialogRole role)
    {
        _modeController.CurrentPhoneScreen.AddItem(text, role);
    }
    private void OnEnableDialogHeader(string text)
    {
        _modeController.CurrentPhoneScreen.SetPhoneHeader(text);
    }
    private void OnSetReaction(string text)
    {
        SceneObjectsHolder.Instance.SetReaction(text);
    }
    private void OnSetLocationToTeleport(string location)
    {
        _teleporter.Teleport(location);
    }
    private void OnSetLocationTextToLocationController(string location)
    {
        _modeController.CurrentInteractScreen.SetLocationText(location);
    }
    private void OnSetLocationToLocationController(string location)
    {
        _locationController.SetLocation(location);
    }
    private void OnSetLocationAfterConnection()
    {
        _locationController.ConnectionEstablished();
    }
    private void OnEnableMovingButton(string button, string buttonName)
    {
        _modeController.BaseReactionButtonsHandler.ShowReactionButtonByName(button, buttonName);
    }
    private void OnSetTimerText(string timerText)
    {
        _modeController.CurrentInteractScreen.SetTimerText(timerText);
    }
    private void OnActivateSceneObjectByName(string id, string name, string time)
    {
        SceneObjectsHolder.Instance.ActivateBaseObjects(id, name, time);
    }
    private void OnActivateSceneArmPointByName(string id, string name)
    {
        SceneObjectsHolder.Instance.ActivateArmUIpoints(id, name);
    }
    private void OnActivatePointObjectByName(string id, string name)
    {
        SceneObjectsHolder.Instance.ActivatePoints(id, name);
    }
    private void OnSetLastScreenText(string headerText, string commentText,string footer,string alarm)
    {
        _modeController.CurrentMenuScreen.ShowMessageScreen(headerText, commentText,footer,alarm);
    }
    private void OnSetResultScreenText(string headerText, string commentText, string evalText)
    {
        _modeController.CurrentMenuScreen.ShowLastScreen(headerText, commentText, evalText);
        _modeController.CurrentMenuController.TeleportByGameTimer();
    }
    private void OnSetExitText(string exitText, string warnText)
    {
        _modeController.CurrentMenuScreen.SetExitText(exitText, warnText);
    }
    private void OnSetMenuText(string headText, string commentText, string exitSureText)
    {
        _modeController.CurrentMenuScreen.SetMenuText(headText, commentText, exitSureText);
    }
    private void OnSetStartText(string headerText, string commentText, string headerFaultText, string commentFaultText)
    {
        _modeController.CurrentStartScreen.SetStartScreenText(headerText, HtmlToText.Instance.HTMLToTextReplace(commentText), headerFaultText, HtmlToText.Instance.HTMLToTextReplace(commentFaultText));
    }
    private void OnShowMenuButton()
    {
        _modeController.CurrentMenuScreen.ShowMenuButtons();
    }
}
