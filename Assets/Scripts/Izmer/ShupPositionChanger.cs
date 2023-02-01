using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShupPositionChanger : MonoBehaviour
{
    [SerializeField] private ShupController _shupController;
    [SerializeField] private List <MeasureButton> _measureButtons;

    public void SetNewShupPositon(Transform pos, string name)
    {
        _shupController.SetShupPosition(pos, name);
    }
}
