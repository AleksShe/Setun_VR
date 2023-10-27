using AosSdk.Core.PlayerModule.Pointer;
using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackTrigger : MonoBehaviour
{
    [SerializeField] private string _locationName;

    private BackButton _backButton;
    private InteractHand _interactHand;
    private void Start()
    {
        _backButton = GetComponentInChildren<BackButton>();
    }
    public string LocationName => _locationName;
    public void EnableTrigger(bool value) => GetComponent<Collider>().enabled = value;
    private void OnTriggerEnter(Collider other)
    {
        var aosObject = other.GetComponentInParent<AosObjectBase>();
        if (!aosObject)
            return;
        _backButton.OnClicked(_interactHand);
        EnableTrigger(false);
    }
}
