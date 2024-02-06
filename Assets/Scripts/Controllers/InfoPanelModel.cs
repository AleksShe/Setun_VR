using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;

public class InfoPanelModel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameText;
    private bool _isOpen = false;
    public void setNameText(string text)
    {
        _nameText.text = text;
    }
    public void ShowInfo()
    {

        if (!_isOpen)
        {
           
          HidePanel();
            HideResultButtons();
           gameObject.SetActive(true);           
            _isOpen = true;
        }
        else
        {
           
            gameObject.SetActive(false);
            _isOpen = false;
        }

    }
    private void HidePanel()
    {
        var panelList = ResultPanelList.Instance.InfoPanelModels;
        foreach (var panel in panelList)
        {
            panel.gameObject.SetActive(false);
            panel.SetOpen(false);
        }
    }
    public void SetOpen(bool open)
    {
        _isOpen = open;
    }
    private void HideResultButtons()
    {
        var buttonsList = ResultPanelList.Instance.ResultButtonsList;
        foreach (var button in buttonsList)
        {
            if (button.Open)
            {
                button.ShowImage();
            }
            
        }
    }
}
