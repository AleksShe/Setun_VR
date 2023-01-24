using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APIEventsInvoker : MonoBehaviour
{
    [SerializeField] private API _api;
    [SerializeField] private ConnectionChecker _connectionChecker;
    //[SerializeField] private MeasureButtonsActivator _measureButtonsActivator;
    [SerializeField] private Teleporter _teleporter;
    //[SerializeField] private LocationController _locationController;
    //[SerializeField] private Diet _diet;
    //[SerializeField] private TimerView _timerView;
    //[SerializeField] private LastScreenController _lastScreenController;
    //[SerializeField] private MenuTextView _menutext;
    //[SerializeField] private StartScreenController _startScreenController;
    //[SerializeField] private MeasureController _measureController;

    private void OnEnable()
    {
        _connectionChecker.OnConnectionReady += OnSetLocationAfterConnection;
        _api.OnShowPlace += OnDeactivateCollidersInStart;
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

    }
    private void OnDisable()
    {
        _connectionChecker.OnConnectionReady -= OnSetLocationAfterConnection;
        _api.OnShowPlace -= OnDeactivateCollidersInStart;
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

    }
    private void OnDeactivateCollidersInStart()
    {
        //AOSColliderActivator.Instance.DeactivateAllColliders();
    }
    private void OnResetMesaureButtons()
    {
        //_measureButtonsActivator.ResetCurrentButtonsList();
    }
    private void OnSetLoationToTeleport(string location)
    {
        _teleporter.Teleport(location);
    }
    private void OnSetLocationTextToLocationController(string location)
    {
        //_locationController.SetLocationtext(location);
    }
    private void OnSetLocationToLocationController(string location)
    {
        //_locationController.SetLocation(location);
        //_diet.EnableDietMeshByLocationName(location);
    }
    private void OnSetLocationAfterConnection()
    {
        //_locationController.ConnectionEstablished();
    }
    private void OnEnableDietButton(string buttonName)
    {
        //_diet.EnablePlusOrMinus(buttonName);
    }
    private void OnEnableMovingButton(string button, string buttonName)
    {
        //MovingButtonsController.Instance.ShowButton(button, buttonName);
    }
    private void OnSetTimerText(string timerText)
    {
        //_timerView.ShowTimerText(timerText);
    }
    private void OnAddButtonToMeasureButtonsList(string buttonName)
    {
        //MeasureButtonsActivator.Instance.AddButtonToList(buttonName);
    }
    private void OnActivateSceneObjectByName(string id, string name)
    {
        //AOSColliderActivator.Instance.ActivateColliders(id, name);
    }
    private void OnSetLastScreenText(string headertext, string commentText)
    {
        //_lastScreenController.ShowMessageScreen(headertext, commentText);
    }
    private void OnSetResultScreenText(string headertext, string commentText, string evalText)
    {
        //_lastScreenController.ShowLastScteen(headertext, commentText, evalText);
    }
    private void OnSetExitText(string exitText, string warntext)
    {
        //_menutext.SetExitText(exitText, warntext);
    }
    private void OnSetMenuText(string headText, string commentText, string exitSureText)
    {
        //_menutext.SetMenuText(headText, commentText, exitSureText);
    }
    private void OnSetStartText(string headerText, string commentText, string buttonText, NextButtonState state)
    {
        //_startScreenController.EnableStartScreen(headerText, HtmlToText.Instance.HTMLToTextReplace(commentText), buttonText, state);
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
