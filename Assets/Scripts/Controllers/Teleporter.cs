using AosSdk.Core.PlayerModule;
using AosSdk.Core.PlayerModule.VRPlayer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Teleporter : MonoBehaviour
{
    public UnityAction<string> TeleportEndEvent;
    public bool CanTeleport { get; set; } = true;
    private bool _menu = false;
    [SerializeField] private Transform _menuPosition;
    [SerializeField] private Transform _hallMachinePosition;
    [SerializeField] private Transform _hallDncPosition;
    [SerializeField] private Transform _hallShnPosition;
    [SerializeField] private Transform _hallFromMachinePosition;
    [SerializeField] private Transform _hallFromDncPosition;
    [SerializeField] private Transform _hallFromShnPosition;
    [Space]
    [SerializeField] private CameraFlash _cameraFlash;
    [SerializeField] private ModeController _modeController;
    [SerializeField] private API _api;

    private Vector3 _currentPlayerPosition = new Vector3();
    private string _previousLocation;

    public void Teleport(string locationName)
    {
        TeleportEndEvent?.Invoke(locationName);
        if (locationName == "start" && _modeController.VrMode)
            TeleportPlayer(_menuPosition);
        if (locationName == "hall" || locationName == "machine_hall" || locationName == "dnc_hall" || locationName == "shn_hall")
        {
            if (_previousLocation == locationName)
                return;
            if (locationName == "hall" && _previousLocation == "machine_hall")
                TeleportPlayer(_hallFromMachinePosition);
            else if (locationName == "hall" && _previousLocation == "dnc_hall")
                TeleportPlayer(_hallFromDncPosition);
            else if (locationName == "hall" && _previousLocation == "shn_hall")
                TeleportPlayer(_hallFromShnPosition);
            else if (locationName == "hall")
                TeleportPlayer(_hallFromMachinePosition);
            else if (locationName == "machine_hall")
                TeleportPlayer(_hallMachinePosition);
            else if (locationName == "dnc_hall")
                TeleportPlayer(_hallDncPosition);
            else if (locationName == "shn_hall")
                TeleportPlayer(_hallShnPosition);
            _previousLocation = locationName;
        }
    }
    public void TeleportToMenu()
    {
        if (!CanTeleport)
            return;
        if (!_menu)
        {
            _menu = true;
            _currentPlayerPosition = new Vector3(_modeController.GetPlayerTransform().position.x, 0.1500001f, _modeController.GetPlayerTransform().position.z); ;
            TeleportPlayer(_menuPosition);
            TeleportEndEvent?.Invoke("menu");
            Player.Instance.CanMove = false;
            _api.OnMenuInvoke();
        }
        else
        {
            _menu = false;
            TeleportPlayer(_currentPlayerPosition);
            Player.Instance.CanMove = true;
        }
    }
    private void TeleportPlayer(Transform newPosition)
    {
        if (!CanTeleport)
            return;
        _cameraFlash.CameraFlashStart();
        Player.Instance.TeleportTo(newPosition);
    }
    private void TeleportPlayer(Vector3 newPos)
    {
        if (!CanTeleport)
            return;
        _cameraFlash.CameraFlashStart();
        Player.Instance.TeleportTo(newPos);
    }
}
