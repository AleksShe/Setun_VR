using UnityEngine;
public class LocationController : MonoBehaviour
{
    [SerializeField] private API _api;
    private string _currentLocation = "hall";
    public string BackLocation { get; set; }
    public void ConnectionEstablished()
    {
        _api.InvokeEndTween(_currentLocation);
    }
    public void SetPreviousLocation()
    {
        _api.InvokeEndTween(BackLocation);
    }
    public void SetLocation(string location)
    {
        _currentLocation = location;
    }
    public string CurrentLocation() => _currentLocation;

}

