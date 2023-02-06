using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimationObject : ObjectWithAnimation
{
    private bool _isOpen = false;
    public override void PlayScriptableAnimation()
    {
        StartCoroutine(RotateDoor());
    }
    private IEnumerator RotateDoor()
    {
        if(!_isOpen)
        {
            int y = 0;
            while (y > -90)
            {
                transform.localRotation = Quaternion.Euler(0, y, 0);
                y--;
                yield return new WaitForSeconds(0.01f);
            }
            _isOpen = true;
        }
        else if(_isOpen)
        {
            int y = -90;
            while (y < 0)
            {
                transform.localRotation = Quaternion.Euler(0, y, 0);
                y++;
                yield return new WaitForSeconds(0.01f);
            }
            _isOpen = false;
        }
    }
}
