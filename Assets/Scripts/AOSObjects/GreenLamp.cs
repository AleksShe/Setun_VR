using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AosSdk.Core.Utils.AosObject(name: "Lamp")]

public class GreenLamp : SceneAosObject
{
    [SerializeField] private GameObject _greenLamp;
    [AosAction(name: "Лампа")]
    public void EnableLamp(bool value)
    {
       _greenLamp.SetActive(value);
    }
}
