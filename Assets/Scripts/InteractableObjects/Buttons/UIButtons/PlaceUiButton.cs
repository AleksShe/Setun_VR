using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaceUiButton : MonoBehaviour
{
    [SerializeField] private GameObject _checkListPanel;
    private Button _button;
    public bool Open;

    private  void Awake()
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

        }
        else
        {
            Open = false;
            _checkListPanel.SetActive(false);
        }
    }
}
