using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimationObject : ObjectWithAnimation
{
    [SerializeField] private bool _side;
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
        GetComponent<Collider>().enabled = false;
        if(value)
        {
            if(!_side)
            {
                int y = -90;
                while (y > -180)
                {
                    transform.localRotation = Quaternion.Euler(0, y, 0);
                    y--;
                    yield return new WaitForSeconds(0.01f);
                }

            }
            else
            {
                int y = 90;
                while (y > 0)
                {
                    transform.localRotation = Quaternion.Euler(0, y, 0);
                    y--;
                    yield return new WaitForSeconds(0.01f);
                }

            }
      
        }
        else if(!value)
        {
            if(!_side)
            {
                int y = -180;
                while (y < -90)
                {
                    transform.localRotation = Quaternion.Euler(0, y, 0);
                    y++;
                    yield return new WaitForSeconds(0.01f);
                }
            }
            else
            {
                int y =0;
                while (y < 90)
                {
                    transform.localRotation = Quaternion.Euler(0, y, 0);
                    y++;
                    yield return new WaitForSeconds(0.01f);
                }
            }
     
        }
    }
}
