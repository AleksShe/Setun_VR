using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateResultButton : MonoBehaviour
{
    [SerializeField] private ResultTextButton _buttonPrefab;
    [SerializeField] private ResultTextButton _buttonSinglePrefab;
    [SerializeField] private GameObject _buttonPanel;
    [SerializeField] private InfoPanelModel _infoPanelPrefab;
    [SerializeField] private GameObject _infoPanel;
   

    public void InstantiateButtons(string nameText, string penalty,string resultText)
    {
        var resultButton = Instantiate(_buttonPrefab, _buttonPanel.transform);
        var infoPanel = Instantiate(_infoPanelPrefab, _infoPanel.transform);
        resultButton.setNameText(nameText);
        resultButton.setPenaltyImage(penalty);
        resultButton.ButtonClickEvent += infoPanel.ShowInfo;
        string text = resultText.Replace("&emsp;", " ").Replace("[", "").Replace("]", "").Replace("\"","");        
        infoPanel.setNameText(text);
        ResultPanelList.Instance.AddResultButton(resultButton);
        ResultPanelList.Instance.AddModel(infoPanel);
    }
    public void InstantiateSingleButtons(string nameText, string penalty)
    {
        var resultButton = Instantiate(_buttonSinglePrefab, _buttonPanel.transform);
        resultButton.setNameText(nameText);
        resultButton.setPenaltyImage(penalty);

    }
}
