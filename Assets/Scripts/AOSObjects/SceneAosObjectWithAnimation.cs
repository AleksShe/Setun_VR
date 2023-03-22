using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
[AosSdk.Core.Utils.AosObject(name: "Анимация")]

public class SceneAosObjectWithAnimation : SceneAosObject
{
   [SerializeField] private HandObjectWithAnimation _handObject;
    [AosAction(name: "Проиграть сломанную анимацию")]
    public void PlayBrokeAnimation()
    {
       
        _handObject.PlayBrokenAnimation();
       
    }

    [AosAction(name: "Проиграть  анимацию починки")]
    public void PlayHandAnimation()
    {
       
        _handObject.HandAction();
        
    }
}
