using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

[AosSdk.Core.Utils.AosObject(name: "Lamp")]

public class AosObjectEnabler : SceneAosObject
{
    [SerializeField] private GameObject _obj;

    [AosAction(name: "�������� ������")]
    public void EnableObject()=> _obj.SetActive(true);
    [AosAction(name: "��������� ������")]
    public void DisableObject() => _obj.SetActive(false);
}
