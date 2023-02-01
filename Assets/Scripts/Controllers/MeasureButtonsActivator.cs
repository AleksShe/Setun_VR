using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MeasureButtonsActivator : MonoBehaviour
{
    [SerializeField] private MeasureButton[] _measureButtons;
    private List<string> _currentButtonsNames = new List<string>();
    public void ActivateMeasureButton(string name)
    {
        var tempButton = _measureButtons.FirstOrDefault(n => n.MeasureButtonObject.ObjectId == name);
        if (tempButton != null)
            tempButton.EnableObject(true);
    }
    public void DeactivateAllButtons()
    {
        foreach (var item in _measureButtons)
        {
            item.EnableObject(false);
        }
    }
    public void ActivateButtonsWithList()
    {
        foreach (var item in _currentButtonsNames)
        {
            ActivateMeasureButton(item);
        }
    }
    public void ResetCurrentButtonsList()
    {
        _currentButtonsNames = new List<string>();
    }
    public void AddButtonToList(string buttonName)
    {
        _currentButtonsNames.Add(buttonName);
    }    

}
