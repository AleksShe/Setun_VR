using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class MenuUiHidingObjects : BaseUIButton
{
    [SerializeField] private GameObject[] _showObjects;
    [SerializeField] private GameObject[] _hideObjects;
    protected override void Click()
    {
        if (_showObjects != null)
        {
            foreach(var item in _showObjects) {
                item.SetActive(true);
            }
        }
           
        if (_hideObjects != null)
        {
            foreach (var item in _hideObjects)
            {
                item.SetActive(false);
            }
            
        }
    }
}
