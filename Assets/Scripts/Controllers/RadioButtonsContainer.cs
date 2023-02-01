using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RadioButtonsContainer : MonoBehaviour
{
    [SerializeField] private AOSRadio[] _buttons;
    public AOSRadio GetButtonPlus(string locationName)
    {
       var Button =  _buttons.FirstOrDefault(b => (b.Location() == locationName) && b.Side());
        if (Button != null)
            return Button;
        else return null;
    }

    public AOSRadio GetButtonMinus(string locationName)
    {
        var Button = _buttons.FirstOrDefault(b => (b.Location() == locationName) && !b.Side());
        if (Button != null)
            return Button;
        else return null;
    }
}
