using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
[AosSdk.Core.Utils.AosObject(name: "��������")]

public class SceneAosObjectWithAnimation : SceneAosObject
{
   [SerializeField] private HandObjectWithAnimation _handObject;
    [AosAction(name: "��������� ��������� ��������")]
    public void PlayBrokeAnimation()
    {
       
        _handObject.PlayBrokenAnimation();
       
    }

    [AosAction(name: "���������  �������� �������")]
    public void PlayHandAnimation()
    {
       
        _handObject.HandAction();
        
    }
}
