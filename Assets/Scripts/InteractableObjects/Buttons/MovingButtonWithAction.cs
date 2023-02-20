using AosSdk.Core.PlayerModule.Pointer;
using UnityEngine;
using UnityEngine.Events;

public class MovingButtonWithAction : MovingButton
{
    public UnityAction<int> ButtonNumberEvent;
    [SerializeField] private ButtonActionName _currentAction;
    private enum ButtonActionName
    {
        Hand,
        Hand_1,
        Hand_2,
        Hand_3,
        Hand_4,
        Eye,
        Eye_1,
        Eye_2,
        Tool,
        Tool_1,
        Pen,
        Pen_1
    }
    public override void OnClicked(InteractHand interactHand)
    {
        if (_currentAction == ButtonActionName.Hand)
        {
            InstanceHandler.Instance.SceneAosObject.ActionWithObject("hand");
            InstanceHandler.Instance.MovingButtonsController.StartHandAction();
            ButtonNumberEvent?.Invoke(0);
        }
        else if (_currentAction == ButtonActionName.Hand_1)
        {
            InstanceHandler.Instance.SceneAosObject.ActionWithObject("hand_1");
            ButtonNumberEvent?.Invoke(1);
        }

        else if (_currentAction == ButtonActionName.Hand_2)
        {
            InstanceHandler.Instance.SceneAosObject.ActionWithObject("hand_2");
            ButtonNumberEvent?.Invoke(2);
        }
        else if (_currentAction == ButtonActionName.Hand_3)
        {
            InstanceHandler.Instance.SceneAosObject.ActionWithObject("hand_3");
            ButtonNumberEvent?.Invoke(3);
        }

        else if (_currentAction == ButtonActionName.Hand_4)
        {
            InstanceHandler.Instance.SceneAosObject.ActionWithObject("hand_4");
            ButtonNumberEvent?.Invoke(4);
        }
        else if (_currentAction == ButtonActionName.Eye)
        {
            InstanceHandler.Instance.SceneAosObject.ActionWithObject("eye");
        }
        else if (_currentAction == ButtonActionName.Eye_1)
        {
            InstanceHandler.Instance.SceneAosObject.ActionWithObject("eye_1");
        }
        else if (_currentAction == ButtonActionName.Eye_2)
        {
            InstanceHandler.Instance.SceneAosObject.ActionWithObject("eye_2");
        }

        else if (_currentAction == ButtonActionName.Tool)
        {
            InstanceHandler.Instance.SceneAosObject.ActionWithObject("tool");
            //InstanceHandler.Instance.MovingButtonsController.PlayToolAnimation();
        }
        else if (_currentAction == ButtonActionName.Tool_1)
        {
            InstanceHandler.Instance.SceneAosObject.ActionWithObject("tool_1");
            //InstanceHandler.Instance.MovingButtonsController.PlayToolAnimation();
        }
        else if (_currentAction == ButtonActionName.Pen)
        {
            InstanceHandler.Instance.SceneAosObject.ActionWithObject("pen");
        }
        else if (_currentAction == ButtonActionName.Pen_1)
        {
            InstanceHandler.Instance.SceneAosObject.ActionWithObject("pen_1");
        }
    }
}
