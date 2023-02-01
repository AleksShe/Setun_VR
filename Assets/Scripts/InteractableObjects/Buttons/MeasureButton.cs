using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;
public class MeasureButton : BaseButton
{
    public override void OnClicked(InteractHand interactHand)
    {

        InstanceHandler.Instance.ShupPositionChanger.SetNewShupPositon(transform,  SceneAOSObject.ObjectId);
    }
    public SceneAosObject MeasureButtonObject => SceneAOSObject;
}