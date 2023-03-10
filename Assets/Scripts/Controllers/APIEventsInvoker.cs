using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APIEventsInvoker : MonoBehaviour
{
    [SerializeField] private API _api;
    [SerializeField] private ConnectionChecker _connectionChecker;

    private void OnEnable()
    {
        _connectionChecker.OnConnectionReady += OnSetLocationAfterConnection;
        _api.OnShowPlace += OnDeactivateColliders;
        _api.OnReaction += OnShowReactionWindow;
        _api.OnPhoneReaction += OnShowPhoneReactionText;
        _api.OnResetMeasureButtons += OnResetMesaureButtons;
        _api.OnSetTeleportLocation += OnSetLoationToTeleport;
        _api.OnSetNewLocationText += OnSetLocationTextToLocationController;
        _api.OnSetLocation += OnSetLocationToLocationController;
        _api.OnSetLocationForFieldColliders += OnActivateStreetColliders;
        _api.OnEnableDietButtons += OnEnableDietButton;
        _api.OnEnableMovingButton += OnEnableMovingButton;
        _api.OnSetTimerText += OnSetTimerText;
        _api.OnAddMeasureButton += OnAddButtonToMeasureButtonsList;
        _api.OnActivateByName += OnActivateSceneObjectByName;
        _api.OnSetMessageText += OnSetLastScreenText;
        _api.OnSetResultText += OnSetResultScreenText;
        _api.OnShowExitText += OnSetExitText;
        _api.OnShowMenuText += OnSetMenuText;
        _api.OnSetStartText += OnSetStartText;
        _api.OnSetMeasureValue += OnSetMeasureValue;
        _api.OnActivateBackButton += OnActivaneBackButton;

    }
    private void OnDisable()
    {
        _connectionChecker.OnConnectionReady -= OnSetLocationAfterConnection;
        _api.OnShowPlace -= OnDeactivateColliders;
        _api.OnReaction -= OnShowReactionWindow;
        _api.OnPhoneReaction -= OnShowPhoneReactionText;
        _api.OnResetMeasureButtons -= OnResetMesaureButtons;
        _api.OnSetTeleportLocation -= OnSetLoationToTeleport;
        _api.OnSetNewLocationText -= OnSetLocationTextToLocationController;
        _api.OnSetLocation -= OnSetLocationToLocationController;
        _api.OnSetLocationForFieldColliders -= OnActivateStreetColliders;
        _api.OnEnableDietButtons -= OnEnableDietButton;
        _api.OnEnableMovingButton -= OnEnableMovingButton;
        _api.OnSetTimerText -= OnSetTimerText;
        _api.OnAddMeasureButton -= OnAddButtonToMeasureButtonsList;
        _api.OnActivateByName -= OnActivateSceneObjectByName;
        _api.OnSetMessageText -= OnSetLastScreenText;
        _api.OnSetResultText -= OnSetResultScreenText;
        _api.OnShowExitText -= OnSetExitText;
        _api.OnShowMenuText -= OnSetMenuText;
        _api.OnSetStartText -= OnSetStartText;
        _api.OnSetMeasureValue -= OnSetMeasureValue;
        _api.OnActivateBackButton -= OnActivaneBackButton;

    }
    private void OnDeactivateColliders()
    {
        InstanceHandler.Instance.AOSColliderActivator.DeactivateAllColliders();
    }
    private void OnShowPhoneReactionText(string text)
    {
        InstanceHandler.Instance.PhoneCanvas.ShowDialogCanvas(text);
    }
    private void OnResetMesaureButtons()
    {
        InstanceHandler.Instance.MeasureButtonsActivator.ResetCurrentButtonsList();
    }
    private void OnShowReactionWindow(string reactionText)
    {
        InstanceHandler.Instance.ReactionInfoWindow.ShowWindowWithText(reactionText);
    }
    private void OnSetLoationToTeleport(string location)
    {
       InstanceHandler.Instance.Teleporter.Teleport(location);
    }
    private void OnSetLocationTextToLocationController(string location)
    {
        InstanceHandler.Instance.LocationController.SetLocationtext(location);
    }
    private void OnSetLocationToLocationController(string location)
    {
        InstanceHandler.Instance.LocationController.SetLocation(location);
    }
    private void OnSetLocationAfterConnection()
    {
        InstanceHandler.Instance.LocationController.ConnectionEstablished();
    }
    private void OnEnableDietButton(string buttonName)
    {
        InstanceHandler.Instance.Diet.EnablePlusOrMinus(buttonName);
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
        InstanceHandler.Instance.TimerView.ShowTimerText(timerText);
    }
    private void OnActivaneBackButton(string actionName)
    {
        InstanceHandler.Instance.BackButtonsActivator.ActionToInvoke = actionName;
        InstanceHandler.Instance.BackButtonsActivator.EnableCurrentBackButton(true);
    }
    private void OnAddButtonToMeasureButtonsList(string buttonName)
    {
       InstanceHandler.Instance.MeasureButtonsActivator.AddButtonToList(buttonName);
    }
    private void OnActivateSceneObjectByName(string id, string name)
    {
        InstanceHandler.Instance.AOSColliderActivator.ActivateColliders(id, name);
    }
    private void OnSetLastScreenText(string headertext, string commentText)
    {
        InstanceHandler.Instance.MainMenuCanvas.ShowCanvasByName("LastWindow");
        InstanceHandler.Instance.MainMenuCanvas.SetText(headertext, commentText);
    }
    private void OnSetResultScreenText(string headertext, string commentText, string evalText)
    {
        InstanceHandler.Instance.MainMenuCanvas.ShowCanvasByName("LastWindow");
        InstanceHandler.Instance.MainMenuCanvas.SetText(headertext, commentText, evalText);
  
    }
    private void OnSetExitText(string exitText, string warntext)
    {
        InstanceHandler.Instance.MainMenuCanvas.SetExitText(exitText, warntext);
    }
    private void OnSetMenuText(string headText, string commentText, string exitSureText)
    {
        InstanceHandler.Instance.MainMenuCanvas.SetMenuText(headText, commentText, exitSureText);
    }
    private void OnSetStartText(string headerText, string commentText, string buttonText, NextButtonState state)
    {
       InstanceHandler.Instance.CanvasChanger.EnableStartScreen(headerText, commentText, buttonText, state);
    }
    private void OnSetMeasureValue(float value)
    {
        //_measureController.SetDeviceValue(value);
    }
    private void OnActivateStreetColliders(string locationName)
    {
        //StreetCollidersActivator.Instance.ActivateColliders(locationName);
    }
}
