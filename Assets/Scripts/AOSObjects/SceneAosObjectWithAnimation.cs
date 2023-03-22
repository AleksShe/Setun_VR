using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneAosObjectWithAnimation : SceneAosObject
{
    private HandObjectWithAnimation _handObject;
    [AosAction(name: "��������� ��������� ��������")]
    public void PlayBrokeAnimation()
    {
        _handObject = GetComponent<HandObjectWithAnimation>();
        if (_handObject = null) return;
        _handObject.PlayBrokenAnimation();
    }

    [AosAction(name: "���������  �������� �������")]
    public void PlayHandAnimation()
    {
        _handObject = GetComponent<HandObjectWithAnimation>();
        if (_handObject = null) return;
        _handObject.HandAction();
    }
}
