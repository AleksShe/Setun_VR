using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUiButtonsHolder : MonoBehaviour
{
    [SerializeField] private MoveUiButton[] _uiButtons;
    public void SetSideMovingObject(BaseSideMovingObject objectToMove)
    {
        if (_uiButtons.Length < 1 || _uiButtons == null)
            return;
        foreach (var uiButton in _uiButtons)
            uiButton.SetSideMovingObject(objectToMove);
    }
}
