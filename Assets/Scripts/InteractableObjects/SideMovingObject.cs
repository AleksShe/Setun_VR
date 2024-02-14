using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMovingObject : BaseSideMovingObject
{
    [SerializeField] private GameObject _objectToMove;
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;
    [SerializeField] private float _minY;
    [SerializeField] private float _maxY;
    [SerializeField] private float _speed;
    private MoveState _currentState = MoveState.None;
    private Vector3 _vectorToAdd;
    private void Start()
    {
        _minX = _minX == 0 ? _objectToMove.transform.localPosition.z : _minX;
        _maxX = _maxX == 0 ? _objectToMove.transform.localPosition.z : _maxX;
        _minY = _minY == 0 ? _objectToMove.transform.localPosition.y : _minY;
        _maxY = _maxY == 0 ? _objectToMove.transform.localPosition.y : _maxY;
    }
    public override void SetMoveSide(MoveState state)
    {
        _currentState = state;
        switch (_currentState)
        {
            case MoveState.None:
                _vectorToAdd = Vector3.zero;
                break;
            case MoveState.Up:
                _vectorToAdd = Vector3.up;
                break;
            case MoveState.Down:
                _vectorToAdd = Vector3.down;
                break;
            case MoveState.Left:
                _vectorToAdd = Vector3.back;
                break;
            case MoveState.Right:
                _vectorToAdd = Vector3.forward;
                break;
        }
    }

    private void Update()
    {
        if (_objectToMove == null || _currentState == MoveState.None)
            return;
        TryMove();
    }

    protected override void TryMove()
    {
        _objectToMove.transform.localPosition += _vectorToAdd * _speed * Time.deltaTime;
        CheckPosition();
    }
    private void CheckPosition()
    {
        if (_objectToMove.transform.localPosition.y >= _maxY)
            _objectToMove.transform.localPosition = new Vector3(_objectToMove.transform.localPosition.x, _maxY, _objectToMove.transform.localPosition.z);
        if (_objectToMove.transform.localPosition.y <= _minY)
            _objectToMove.transform.localPosition = new Vector3(_objectToMove.transform.localPosition.x, _minY, _objectToMove.transform.localPosition.z);
        if (_objectToMove.transform.localPosition.z >= _maxX)
            _objectToMove.transform.localPosition = new Vector3(_objectToMove.transform.localPosition.x, _objectToMove.transform.localPosition.y, _maxX);
        if (_objectToMove.transform.localPosition.z <= _minX)
            _objectToMove.transform.localPosition = new Vector3(_objectToMove.transform.localPosition.x, _objectToMove.transform.localPosition.y, _minX);
    }
}
