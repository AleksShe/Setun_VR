using AosSdk.Core.PlayerModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Teleporter : MonoBehaviour
{
    public UnityAction<string> OnTeleportEnd;
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
    [SerializeField] private CameraFadeIn _cameraFadeIn;
    [SerializeField] private ModeController _modeController;

    private Vector3 _currentPlayerPosition = new Vector3();
    private string _previousLocation;

    
    public void Teleport(string locationName)
    {
        OnTeleportEnd?.Invoke(locationName);
        if (locationName == "start")
            TeleportPlayer(_menuPosition);
        if (locationName == "hall" || locationName == "machine_hall" || locationName == "dnc_hall" || locationName == "shn_hall")
        {
            if (_previousLocation == locationName)
                return;
            if (locationName == "hall" && _previousLocation == "machine_hall")
            {
                TeleportPlayer(_hallFromMachinePosition);
            }
            else if (locationName == "hall" && _previousLocation == "dnc_hall")
            {
                TeleportPlayer(_hallFromDncPosition);
            }
            else if (locationName == "hall" && _previousLocation == "shn_hall")
            {
                TeleportPlayer(_hallFromShnPosition);
            }
            else if (locationName == "hall")
            {
                TeleportPlayer(_hallFromMachinePosition);
            }

            else if (locationName == "machine_hall")
            {
                TeleportPlayer(_hallMachinePosition);
            }
            else if (locationName == "dnc_hall")
            {
                TeleportPlayer(_hallDncPosition);
            }
            else if (locationName == "shn_hall")
            {
                TeleportPlayer(_hallShnPosition);
            }
            _previousLocation = locationName;
        }
    }
    public void TeleportToMenu()
    {
        if (!_menu)
        {
            _menu = true;
            _currentPlayerPosition = new Vector3(_modeController.GetPlayerTransform().position.x, 0.1500001f, _modeController.GetPlayerTransform().position.z); ;
            TeleportPlayer(_menuPosition);
            OnTeleportEnd?.Invoke("menu");
        }
        else
        {
            _menu = false;
            TeleportPlayer(_currentPlayerPosition);
        }
    }

    private void TeleportPlayer(Transform newPosition)
    {
        _cameraFadeIn.FadeStart = true;
        _cameraFadeIn.StartFade();
        Player.Instance.TeleportTo(newPosition);
    }
    private void TeleportPlayer(Vector3 newPos)
    {
        if (!CanTeleport)
            return;
        _cameraFadeIn.FadeStart = true;
        _cameraFadeIn.StartFade();
        Player.Instance.TeleportTo(newPos);
    }

}
