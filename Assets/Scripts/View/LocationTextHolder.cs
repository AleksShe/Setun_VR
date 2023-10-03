using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LocationTextHolder : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _locationText;
    public void SetLocationText(string location) => _locationText.text = location;
}
