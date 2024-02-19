using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceUiButton : MonoBehaviour
{
    [SerializeField] private GameObject _checkListPanel;
    [SerializeField] private PlaceUiButton[] _placeUiButton;
    [SerializeField] private GameObject _buttonImage;
    [SerializeField] private OtkazAOSUIButton[] _otkazButton;
    [SerializeField] private Image _dotImage;
    [SerializeField] private Sprite _selectedDotOk;
    [SerializeField] private Sprite _selectedDotNotOk;

    private Button _button;
    public bool Open;

    private void Awake()
    {
        _button = GetComponent<Button>();
        if (_button != null)
            _button.onClick.AddListener(() => Click());
    }
    public void Click()
    {
        if (!Open)
        {
            Open = true;
            _checkListPanel.SetActive(true);
            _buttonImage.SetActive(true);
            foreach (var placeButton in _placeUiButton)
            {
                if (placeButton.Open)
                {
                    placeButton.Click();
                }
            }
        }
        else
        {
            Open = false;
            _checkListPanel.SetActive(false);
            _buttonImage.SetActive(false);
        }
    }
    public void SetDotSprite(bool check)
    {
        if (check)
        {
            _dotImage.sprite = _selectedDotNotOk;
        }
        else
        {
            _dotImage.sprite = _selectedDotOk;
        }
    }
}
