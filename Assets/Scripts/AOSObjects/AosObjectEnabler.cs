using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AosSdk.Core.Utils.AosObject(name: "Object enabler")]

public class AosObjectEnabler : SceneAosObject
{
    [SerializeField] private GameObject _obj;

    [AosAction(name: "Включить объект")]
    public void EnableObject()=> _obj.SetActive(true);
    [AosAction(name: "Выключить объект")]
    public void DisableObject() => _obj.SetActive(false);
}
