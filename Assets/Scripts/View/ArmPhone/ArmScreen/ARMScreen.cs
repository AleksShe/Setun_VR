using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARMScreen : BaseScreen
{
    [SerializeField] private GameObject _11Arm;
    [SerializeField] private GameObject _16Arm;
    [SerializeField] private GameObject _shnArm;
    public override void ActivateScreen(bool active) => Screen.SetActive(active);

    public string CheckArmState()
    {

        if (_11Arm.activeSelf)
            return "11";
         if(_16Arm.activeSelf)
            return "16";
        if (_shnArm.activeSelf)
            return "shn";
        else return "0";
    }
}
