using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceDynamicUiButton : MonoBehaviour
{
       
    [SerializeField] private GameObject _buttonImage;
    [SerializeField] private Image _dotImage;
    [SerializeField] private Sprite _selectedDotOk;
    [SerializeField] private Sprite _selectedDotNotOk;
    [SerializeField] private Text _text;
    private List<PlaceDynamicUiButton> _buttons = new List<PlaceDynamicUiButton>();
    private GameObject _checkListPanel;

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
            foreach (var placeButton in _buttons)
            {
                if (placeButton.Open)
                {
                    placeButton.Click();
                }
            }
            Open = true;
            _checkListPanel.SetActive(true);
            _buttonImage.SetActive(true);
            
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
    public void SetText(string text)
    {     
        _text.text = text;
    }
    public void SetListButtons(List<PlaceDynamicUiButton> buttons)
    {
        _buttons = buttons;
    }
    public void SetCheckList(GameObject checkList)
    {
        _checkListPanel = checkList;
    }

}
