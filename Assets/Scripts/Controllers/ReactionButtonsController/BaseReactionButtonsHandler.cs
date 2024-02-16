using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ButtonActionName
{
    hand,
    hand_1,
    hand_2,
    hand_3,
    hand_4,
    eye,
    tool,
    tool_1,
    pen,
    pen_1
}

public abstract class BaseReactionButtonsHandler : MonoBehaviour
{
    public abstract void ShowReactionButtonByName(string buttonActionName, string buttonText);
    protected StringParser StringParser;
    protected Vector3 ButtonsSpawnPos;
    protected virtual void Start()
    {
        StringParser = new StringParser();
    }
    public void SetButtonSpawnPos(Vector3 newPos)
    {
        ButtonsSpawnPos = newPos;
    }
    public abstract void HideAllReactions();

}
