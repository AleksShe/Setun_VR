using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
            Debug.Log("OPEN");
          
           gameObject.SetActive(true);           
            _isOpen = true;
        }
        else
        {
            Debug.Log("Close");
            gameObject.SetActive(false);
            _isOpen = false;
        }

    }
}
