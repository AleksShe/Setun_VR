using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneAosObjectWithAnimation : SceneAosObject
{
    private HandObjectWithAnimation _handObject;
    [AosAction(name: "Проиграть сломанную анимацию")]
    public void PlayBrokeAnimation()
    {
        _handObject = GetComponent<HandObjectWithAnimation>();
        if (_handObject = null) return;
        _handObject.PlayBrokenAnimation();
    }

    [AosAction(name: "Проиграть  анимацию починки")]
    public void PlayHandAnimation()
    {
        _handObject = GetComponent<HandObjectWithAnimation>();
        if (_handObject = null) return;
        _handObject.HandAction();
    }
}
