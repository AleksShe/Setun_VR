using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ResultTextButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private Image _openImage;
    [SerializeField] private Image _penaltyImage;
    [SerializeField] private Sprite _okImage;
    [SerializeField] private Sprite _notOkImage;

    public bool Open = false;

    public UnityAction ButtonClickEvent;
    private Button _button;
    private void Awake()
    {
        _button = GetComponent<Button>();
    }
    private void Start()
    {
        _button.onClick.AddListener(() => { ButtonClickEvent?.Invoke(); });
        _button.onClick.AddListener(ShowImage);
    }
    public void setNameText(string text) => _nameText.text = text;
    public void setPenaltyImage(string penalty)
    {
        if (penalty == "0")
        {
            _penaltyImage.sprite = _okImage;
        }
        else if (penalty == "1")
        {
            _penaltyImage.sprite = _notOkImage;
        }
    }
    public void ShowImage()
    {
        if (!Open)
        {
            Open = true;
            _openImage.gameObject.SetActive(true);
        }
        else
        {
            Open = false;
            _openImage.gameObject.SetActive(false);
        }
    }
}
