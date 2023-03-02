using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PcDoorAnimation : ObjectWithAnimation
{
    [SerializeField] private GameObject _door;
    private bool _isOpen = false;
    public override void PlayScriptableAnimationOpen()
    {
        StartCoroutine(RotateDoor(true));
    }
    public override void PlayScriptableAnimationClose()
    {
        StartCoroutine(RotateDoor(false));
    }
    private IEnumerator RotateDoor(bool value)
    {
        if (value)
        {
            if (!_isOpen)
            {
                int x = 0;
                while (x < 90)
                {
                    _door.transform.localRotation = Quaternion.Euler(x, 0, 0);

                    x++;
                    yield return new WaitForSeconds(0.005f);
                }
                _isOpen = true;
            }
        }
        else if (!value)
        {
            if(_isOpen)
            {
                int x = 90;
                while (x > 0)
                {
                    _door.transform.localRotation = Quaternion.Euler(x, 0, 0);
                    x--;
                    yield return new WaitForSeconds(0.005f);
                }
                _isOpen = false;
            }
             }
    }
}

