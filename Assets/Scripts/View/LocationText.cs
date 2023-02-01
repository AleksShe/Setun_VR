using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LocationText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _deskLocationText;
    [SerializeField] private TextMeshProUGUI _vrLocationText;
    public void SetLocationText(string location)
    {
        _deskLocationText.text = location;
        _vrLocationText.text = location;
    }
}
