using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneCanvasEnable : MonoBehaviour
{
    [SerializeField] private BackButton _backButton;
    [SerializeField] private BackButton _backFromPhoneButton;
    [SerializeField] private PhoneObjectWithButton _phoneObject;
    [SerializeField] private PhoneObjectWithButton _phoneButtonObject;
    [SerializeField] private BackButton _prevousbackButton;

    private Canvas _canvas;

    private void Start() => _canvas = GetComponent<Canvas>();
    private void OnEnable()
    {
        _backButton.BackButtonClickEvent += OnHideCanvas;
        _phoneObject.ClickPhoneObjectEvent += OnShowCanvas;
        _phoneButtonObject.ClickPhoneObjectEvent += OnShowCanvas;
        _backFromPhoneButton.BackButtonClickEvent += OnHideCanvasInCanvas;
    }
    private void OnDisable()
    {
        _backButton.BackButtonClickEvent -= OnHideCanvas;
        _phoneObject.ClickPhoneObjectEvent -= OnShowCanvas;
        _phoneButtonObject.ClickPhoneObjectEvent -= OnShowCanvas;
        _backFromPhoneButton.BackButtonClickEvent -= OnHideCanvasInCanvas;
    }
    private void OnHideCanvasInCanvas()
    {
        InstanceHandler.Instance.BackButtonsActivator.EnableCurrentBackButton(false);
        InstanceHandler.Instance.BackButtonsActivator.SetCurrentBackButton(_backButton);
        InstanceHandler.Instance.BackButtonsActivator.EnableCurrentBackButton(true);
    }
    private void OnHideCanvas()
    {
        _canvas.enabled=false;
        InstanceHandler.Instance.BackButtonsActivator.EnableCurrentBackButton(false);
        InstanceHandler.Instance.BackButtonsActivator.SetCurrentBackButton(_prevousbackButton);
        InstanceHandler.Instance.BackButtonsActivator.EnableCurrentBackButton(true);
    }
    private void OnShowCanvas() => _canvas.enabled = true;
}
