using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
public class LocationController : MonoBehaviour
{
    [SerializeField] private API _api;

    private string _currentLocation = "field";
    public string GetLocationName => _currentLocation;
    public void ConnectionEstablished() => _api.ConnectionEstablished(_currentLocation);
    public void SetLocation(string location) => _currentLocation = location;
}
