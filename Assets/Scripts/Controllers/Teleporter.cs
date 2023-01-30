using AosSdk.Core.PlayerModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _hallMachinePosition;
    [SerializeField] private Transform _hallDncPosition;
    [SerializeField] private Transform _hallShnPosition;
    [SerializeField] private Transform _hallFromMachinePosition;
    [SerializeField] private Transform _hallFromDncPosition;
    [SerializeField] private Transform _hallFromShnPosition;
    [SerializeField] private CameraFadeIn _cameraFadeIn;

    public UnityAction<string> OnTeleportEnd;

    private string _previousLocation;
    
    public void Teleport(string locationName)
    {
        OnTeleportEnd?.Invoke(locationName);
        if (locationName == "start")
            TeleportPlayer(_startPosition);
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

        private void TeleportPlayer(Transform newPosition)
    {
        _cameraFadeIn.FadeStart = true;
        _cameraFadeIn.StartFade();
        Player.Instance.TeleportTo(newPosition);
    }

}
