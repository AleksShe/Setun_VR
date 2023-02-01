using System.Collections;
using System.ComponentModel;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
[AosSdk.Core.Utils.AosObject(name: "Амперметр")]
public class AOSAmpermetr : AosObjectBase
{
    [SerializeField] private GameObject _leverArm;
    [SerializeField] private FuseAmperButton _fuse;
    [SerializeField] private PointerDevice _pointerDevice;
    [SerializeField] private MeasureController _measureController;
    private string _napr;
    private string _voltage;
    public void SetCondition(float value)
    {
        if (value < 0)
            _fuse.ResetButton();
        else if (value <= 0.5f)
            _leverArm.transform.localRotation = Quaternion.Euler(0, -135f, 0);
        else if (value <= 2.5f)
            _leverArm.transform.localRotation = Quaternion.Euler(0, -120f, 0);
        else if (value <= 10f)
            _leverArm.transform.localRotation = Quaternion.Euler(0, -105f, 0);
        else if (value <= 25f)
            _leverArm.transform.localRotation = Quaternion.Euler(0, -90f, 0);
        else if (value <= 50f)
            _leverArm.transform.localRotation = Quaternion.Euler(0, -75f, 0);
        else if (value <= 100f)
            _leverArm.transform.localRotation = Quaternion.Euler(0, -60f, 0);
        else if (value <= 250f)
            _leverArm.transform.localRotation = Quaternion.Euler(0, -45f, 0);
        else if (value <= 500f)
            _leverArm.transform.localRotation = Quaternion.Euler(0, -30f, 0);
        else if (value <= 1000f)
            _leverArm.transform.localRotation = Quaternion.Euler(0, -15f, 0);
        else if (value > 1000)
            _fuse.ResetButton();
    }


    public void SetVoltage(string voltage)
    {
        _voltage = voltage;
        SetIzmerValue();
    }
    public void SetNapr(string napr)
    {
        _napr = napr;
        SetIzmerValue();
    }
    public void SetIzmerValue()
    {
        if (_napr == "Perem" && _voltage == "mA" || _napr == "Perem" && _voltage == "A")
            _measureController.SetTypeText("acl");
        else if (_napr == "Post" && _voltage == "mA" || _napr == "Post" && _voltage == "A")
            _measureController.SetTypeText("dcl");
        else if (_napr == "Perem" && _voltage == "V")
            _measureController.SetTypeText("acU");
        else if (_napr == "Post" && _voltage == "V")
            _measureController.SetTypeText("dcU");
        else if (_napr == "Sopr" && _voltage == "R")
            _measureController.SetTypeText("ohm");
        else _measureController.SetTypeText(null);
    }

}
