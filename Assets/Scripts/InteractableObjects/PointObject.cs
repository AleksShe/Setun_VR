using AosSdk.Core.PlayerModule.Pointer;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointObject : BaseObject
{
    [SerializeField] private TextMeshProUGUI _pointText;
    private Button _button;
    private bool _uiPointer;
    private void Start()
    {
        _button = GetComponent<Button>();
        if (_button != null)
        {
            _button.onClick.AddListener(() => InvokeAosEvent());
            _uiPointer = true;
        }
        EnableObject(false);
        //InstanceHandler.Instance.AOSColliderActivator.AddPointObject(this);
    }
    public void SetPointText(string text) => _pointText.text = text;
    public override void EnableObject(bool value)
    {
        GetComponent<Image>().enabled = value;
        _pointText.enabled = value;
        if (_uiPointer)
            _button.enabled = value;
        else
            GetComponent<Collider>().enabled = value;
    }
}
