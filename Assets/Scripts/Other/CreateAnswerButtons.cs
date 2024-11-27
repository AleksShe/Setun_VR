using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAnswerButtons : MonoBehaviour
{
    [SerializeField] private PlaceDynamicUiButton _placeButton;
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameObject _buttonsPanel;
    [SerializeField] private Transform _buttonsPanelTransform;
    [SerializeField] private GameObject _answerButton;
    [SerializeField] private AnswerUIButton _answerUIButton;
    public List<PlaceDynamicUiButton> buttons = new List<PlaceDynamicUiButton>();
    public List<AnswerOptionsButton> AnswerOptionsButtons = new List<AnswerOptionsButton>();

    public void CreatePlaceButton(string name, string attemp, List<AnswerButtonObject> listButtons)
    {    
        var button = Instantiate(_placeButton,_panel.transform);
        button.SetText(name);
     
        buttons.Add(button);
        button.SetListButtons(buttons);
        var buttonsPanel = Instantiate(_buttonsPanel, _buttonsPanelTransform);
      
        button.SetCheckList(buttonsPanel);
        foreach (var item in listButtons)
        {
            var answerButton = Instantiate(_answerButton, buttonsPanel.transform.GetChild(0));
            var answerOptionButton = answerButton.GetComponent<AnswerOptionsButton>();
            answerOptionButton.SetButtonIdAndText(item.Id, item.Name);
            answerOptionButton.SetButtons(_answerUIButton, button);
            AnswerOptionsButtons.Add(answerOptionButton);
           
        }
        _answerUIButton.AddButton(AnswerOptionsButtons);
    }
}
