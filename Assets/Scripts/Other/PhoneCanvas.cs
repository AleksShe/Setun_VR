using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PhoneCanvas : MonoBehaviour
{
    [SerializeField] private BackButton _backButton;
    [SerializeField] private GameObject _buttonsCanvas;
    [SerializeField] private GameObject _dialogCanvas;
    [SerializeField] private TextMeshProUGUI _dialogText;
    [SerializeField] private BackFromDialogButton _backDialogButton;
    private void OnEnable()
    {
        _backDialogButton.ClickBackDialogEvent += OnHideDialogCanvas;
        _backButton.BackButtonClickEvent += OnHideDialogCanvas;
    }
    private void OnDisable()
    {
        _backDialogButton.ClickBackDialogEvent -= OnHideDialogCanvas;
        _backButton.BackButtonClickEvent -= OnHideDialogCanvas;
    }
    public void ShowDialogCanvas(string text)
    {
        _dialogCanvas.SetActive(true);
        _buttonsCanvas.SetActive(false);
        _dialogText.text = text;
    }
    private void OnHideDialogCanvas()
    {
        _dialogCanvas.SetActive(false);
        _buttonsCanvas.SetActive(true);
    }
}
