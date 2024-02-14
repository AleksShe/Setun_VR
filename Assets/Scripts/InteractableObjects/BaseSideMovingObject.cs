using UnityEngine;

public abstract class BaseSideMovingObject : MonoBehaviour
{
    public abstract void SetMoveSide(MoveState state);
    protected abstract void TryMove();
}
