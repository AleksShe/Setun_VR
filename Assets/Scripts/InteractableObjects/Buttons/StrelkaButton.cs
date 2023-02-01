using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;
public class StrelkaButton : BaseButton
{
    [SerializeField] private bool _side;
    public UnityAction OnStrelkaButtonClicked;
    public override void OnClicked(InteractHand interactHand)
    {
        if (_side)
        {
          var  button = InstanceHandler.Instance.RadioButtonsContainer.GetButtonPlus(InstanceHandler.Instance.LocationController.GetLocationName);
            button.InvokeOnClick();
        }
        else
        {
           var button = InstanceHandler.Instance.RadioButtonsContainer.GetButtonMinus(InstanceHandler.Instance.LocationController.GetLocationName);
            button.InvokeOnClick();
        }
        OnStrelkaButtonClicked?.Invoke();
    }
}
