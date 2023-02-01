using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;
public class BackButton : BaseButton
{
    //[SerializeField] private ScenaAosObjectWithAnimation _animationObject;
    //[SerializeField] private BackTriggerObject _backTriggerObj;
    public override void OnClicked(InteractHand interactHand)
    {
        InstanceHandler.Instance.MovingButtonsController.HideAllButtons();
        API api = FindObjectOfType<API>();
        api.OnInvokeNavAction(InstanceHandler.Instance.BackButtonsActivator.ActionToInvoke);
        //ShupController shup = FindObjectOfType<ShupController>();
        //shup.ResetShupPosition();
        //if (_animationObject != null)
        //{
        //    _animationObject.PlayCloseAnimation();
        //}
        //AOSColliderActivator.Instance.CanTouch = true;
        //BackButtonsActivator.Instance.SetBackButtonObject(null);
        //_backTriggerObj.EnableBackTriggerObject(false);
    }

}
