using AosSdk.Core.PlayerModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APIEventsInvoker : MonoBehaviour
{
    [SerializeField] private API _api;
    [SerializeField] private ConnectionToClient _connectionChecker;

    private void OnEnable()
    {
        _connectionChecker.ConnectionReadyEvent += OnSetLocationAfterConnection;
        _api.ShowPlaceEvent += OnDeactivateColliders;
        _api.ReactionEvent += OnShowReactionWindow;
        _api.SetTeleportLocationEvent += OnSetLocationToTeleport;
        _api.SetNewLocationTextEvent += OnSetLocationTextToLocationController;
        _api.SetLocationEvent += OnSetLocationToLocationController;
        _api.EnableMovingButtonEvent += OnEnableMovingButton;
        _api.SetTimerTextEvent += OnSetTimerText;
        _api.ActivateByNameEvent += OnActivateSceneObjectByName;
        _api.SetMessageTextEvent += OnSetLastScreenText;
        _api.SetResultTextEvent += OnSetResultScreenText;
        _api.ShowExitTextEvent += OnSetExitText;
        _api.ShowMenuTextEvent += OnSetMenuText;
        _api.SetStartTextEvent += OnSetStartText;
        _api.ActivateBackButtonEvent += OnActivaneBackButton;
        _api.PointEvent += OnActivatePointObjectByName;
        _api.DialogHeaderEvent += OnEnableDialogHeader;
        _api.DialogEvent += OnEnableDialog;
        _api.AddTextObjectUiButtonEvent += OnAddTextObjectUiButton;
        _api.AddTextObjectUiEvent += OnAddTextObjectUi;
    }

    private void OnDisable()
    {
        _connectionChecker.ConnectionReadyEvent -= OnSetLocationAfterConnection;
        _api.ShowPlaceEvent -= OnDeactivateColliders;
        _api.ReactionEvent -= OnShowReactionWindow;
        _api.SetTeleportLocationEvent -= OnSetLocationToTeleport;
        _api.SetNewLocationTextEvent -= OnSetLocationTextToLocationController;
        _api.SetLocationEvent -= OnSetLocationToLocationController;
        _api.EnableMovingButtonEvent -= OnEnableMovingButton;
        _api.SetTimerTextEvent -= OnSetTimerText;
        _api.ActivateByNameEvent -= OnActivateSceneObjectByName;
        _api.SetMessageTextEvent -= OnSetLastScreenText;
        _api.SetResultTextEvent -= OnSetResultScreenText;
        _api.ShowExitTextEvent -= OnSetExitText;
        _api.ShowMenuTextEvent -= OnSetMenuText;
        _api.SetStartTextEvent -= OnSetStartText;
        _api.ActivateBackButtonEvent -= OnActivaneBackButton;
        _api.PointEvent -= OnActivatePointObjectByName;
        _api.DialogHeaderEvent -= OnEnableDialogHeader;
        _api.DialogEvent -= OnEnableDialog;
        _api.AddTextObjectUiButtonEvent -= OnAddTextObjectUiButton;
        _api.AddTextObjectUiEvent -= OnAddTextObjectUi;
    }
    private void OnDeactivateColliders()
    {
        InstanceHandler.Instance.AOSColliderActivator.DeactivateAllColliders();
    }
    private void OnShowPhoneReactionText(string text)
    {
     
    }
    private void OnEnableDialog(string text)
    {
        InstanceHandler.Instance.CanvasMode.EnableDialogCanvas(text);
    }
    private void OnAddTextObjectUiButton(string id,string name)
    {
        InstanceHandler.Instance.CanvasMode.AddTextObjectUiButton(id, name);
    }
    private void OnAddTextObjectUi(string text)
    {
        InstanceHandler.Instance.CanvasMode.AddTextObjectUi(text);
    }
    private void OnEnableDialogHeader(string text)
    {
        InstanceHandler.Instance.CanvasMode.SetDialogHeaderText(text);
        Debug.Log("header is "+ text);
    }
    private void OnShowReactionWindow(string reactionText)
    {
        InstanceHandler.Instance.HelpTextController.SetReactionText(reactionText);
    }
    private void OnSetLocationToTeleport(string location)
    {
       InstanceHandler.Instance.Teleporter.Teleport(location);
    }
    private void OnSetLocationTextToLocationController(string location)
    {
        InstanceHandler.Instance.CanvasMode.SetLocationtext(location);
    }
    private void OnSetLocationToLocationController(string location)
    {
        InstanceHandler.Instance.LocationController.SetLocation(location);
    }
    private void OnSetLocationAfterConnection()
    {
        InstanceHandler.Instance.LocationController.ConnectionEstablished();
    }

    private void OnEnableMovingButton(string buttonType, string buttonText)
    {
        if (buttonType == "eye")
        {
            InstanceHandler.Instance.MovingButtonsController.ShowWatchButton();
            InstanceHandler.Instance.MovingButtonsController.SetWatchButtonText(buttonText);
        }
        else if (buttonType == "eye_1")
        {
            InstanceHandler.Instance.MovingButtonsController.ShowWatch1Button();
            InstanceHandler.Instance.MovingButtonsController.SetWatch1ButtonText(buttonText);
        }
        else if (buttonType == "eye_2")
        {
            InstanceHandler.Instance.MovingButtonsController.ShowWatch2Button();
            InstanceHandler.Instance.MovingButtonsController.SetWatch2ButtonText(buttonText);
        }
        else if (buttonType == "hand")
        {
            InstanceHandler.Instance.MovingButtonsController.ShowHandButton();
            InstanceHandler.Instance.MovingButtonsController.SetHandButtonText(buttonText);
        }
        else if (buttonType == "hand_1")
        {
            InstanceHandler.Instance.MovingButtonsController.ShowHand1Button();
            InstanceHandler.Instance.MovingButtonsController.SetHand1ButtonText(buttonText);
        }
        else if (buttonType == "hand_2")
        {
            InstanceHandler.Instance.MovingButtonsController.ShowHand2Button();
            InstanceHandler.Instance.MovingButtonsController.SetHand2ButtonText(buttonText);
        }
        else if (buttonType == "hand_3")
        {
            InstanceHandler.Instance.MovingButtonsController.ShowHand3Button();
            InstanceHandler.Instance.MovingButtonsController.SetHand3ButtonText(buttonText);
        }
        else if (buttonType == "hand_4")
        {
            InstanceHandler.Instance.MovingButtonsController.ShowHand4Button();
            InstanceHandler.Instance.MovingButtonsController.SetHand4ButtonText(buttonText);
        }
        else if (buttonType == "tool")
        {
            InstanceHandler.Instance.MovingButtonsController.ShowToolButton();
            InstanceHandler.Instance.MovingButtonsController.SetToolButtonText(buttonText);
        }
        else if (buttonType == "tool_1")
        {
            InstanceHandler.Instance.MovingButtonsController.ShowTool1Button();
            InstanceHandler.Instance.MovingButtonsController.SetTool1ButtonText(buttonText);
        }
        else if (buttonType == "pen")
        {
            InstanceHandler.Instance.MovingButtonsController.ShowPenButton();
            InstanceHandler.Instance.MovingButtonsController.SetPenButtonText(buttonText);
        }
        else if (buttonType == "pen_1")
        {
            InstanceHandler.Instance.MovingButtonsController.ShowPen1Button();
            InstanceHandler.Instance.MovingButtonsController.SetPen1ButtonText(buttonText);
        }

        else if (buttonType == null)
            InstanceHandler.Instance.MovingButtonsController.HideAllButtons();
    }
    private void OnSetTimerText(string timerText)
    {
        InstanceHandler.Instance.CanvasMode.SetTimeText(timerText);
    }
    private void OnActivaneBackButton(string actionName)
    {
        InstanceHandler.Instance.BackButtonsActivator.ActionToInvoke = actionName;
        InstanceHandler.Instance.BackButtonsActivator.EnableCurrentBackButton(true);
    }
    private void OnActivateSceneObjectByName(string id, string name)
    {
        InstanceHandler.Instance.AOSColliderActivator.ActivateColliders(id, name);
    }
    private void OnActivatePointObjectByName(string id, string name)
    {
        InstanceHandler.Instance.AOSColliderActivator.ActivatePoints(id, name);
    }
    private void OnSetLastScreenText(string headertext, string commentText)
    {
        InstanceHandler.Instance.CanvasMode.SetLastScreenText(headertext, commentText);
    }
    private void OnSetResultScreenText(string headertext, string commentText, string evalText)
    {
        InstanceHandler.Instance.CanvasMode.SetResultScreenText(headertext, commentText, evalText);
    }
    private void OnSetExitText(string exitText, string warntext)
    {
        InstanceHandler.Instance.CanvasMode.SetExitText(exitText, warntext);
    }
    private void OnSetMenuText(string headText, string commentText, string exitSureText)
    {
        InstanceHandler.Instance.CanvasMode.SetMenuText(headText, commentText, exitSureText);
    }
    private void OnSetStartText(string headerText, string commentText, string buttonText, NextButtonState state)
    {
       InstanceHandler.Instance.CanvasMode.SetStartScreenText(headerText, commentText, buttonText, state);
    }
}
