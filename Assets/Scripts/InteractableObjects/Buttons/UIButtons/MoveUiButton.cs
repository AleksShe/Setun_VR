using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public enum MoveState
{
    None,
    Up,
    Down,
    Left,
    Right
}
public class MoveUiButton : BaseUIButton
{
    [SerializeField] private MoveState _moveState;
    [SerializeField] private GameObject _sprite;
    private BaseSideMovingObject _baseSideMovingObject;
    public Action PointerEnterEvent;
    public Action PointerExitEvent;
    public void SetSideMovingObject(BaseSideMovingObject obj)
    {
        if(obj!=null)
        {
            if(_sprite!=null)
                _sprite.SetActive(true);
        }
        else
        {
            if (_sprite != null)
                _sprite.SetActive(false);
        }
        _baseSideMovingObject = obj;
    }
    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (_baseSideMovingObject != null)
        {
            _baseSideMovingObject.SetMoveSide(_moveState);
            PointerEnterEvent?.Invoke();
        }
           
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
        if (_baseSideMovingObject != null)
        {
            _baseSideMovingObject.SetMoveSide(MoveState.None);
            PointerExitEvent?.Invoke();
        }
    }
}
