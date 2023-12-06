using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BackTriggersHolder : MonoBehaviour
{
    [SerializeField] private BackTrigger[] _backTriggers;
    private BackTrigger _currentTrigger;

    public void SetTrigger(string locationName)
    {
        try
        {
            var trigger = _backTriggers.FirstOrDefault(t => t.LocationName == locationName);
            Debug.Log(trigger.LocationName + " Trigger location name");
            if (trigger == null)
                return;
            _currentTrigger = trigger;
        }
        catch(Exception ex) 
        {
            Debug.Log(ex);
        }
    }
    public void EnableCurrentTrigger(bool value)
    {
        if (_currentTrigger == null)
            return;
        _currentTrigger.EnableTrigger(value);
    }
}
