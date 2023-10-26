using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimationObject : ObjectWithAnimation
{
    [SerializeField] private bool _side;
    [SerializeField] private GameObject _door;
    public override void PlayScriptableAnimationOpen() => StartCoroutine(RotateDoor(true));
    public override void PlayScriptableAnimationClose() => StartCoroutine(RotateDoor(false));
    private IEnumerator RotateDoor(bool value)
    {
        GetComponent<Collider>().enabled = false;
        if(value)
        {
            InstanceHandler.Instance.DoorSoundPlayer.PlayOpenMetalDoorSound();
            if (!_side)
            {
                int y = 0;
                while (y > -90)
                {
                    _door.transform.localRotation = Quaternion.Euler(0, y, 0);
                    y--;
                    yield return new WaitForSeconds(0.01f);
                }

            }
            else
            {
                int y = 0;
                while (y > -90)
                {
                    _door.transform.localRotation = Quaternion.Euler(0, y, 0);
                    y--;
                    yield return new WaitForSeconds(0.01f);
                }
            }
        }
        else if(!value)
        {
            
            if (!_side)
            {
                int y = -90;
                while (y < 0)
                {
                    _door.transform.localRotation = Quaternion.Euler(0, y, 0);
                    y++;
                    yield return new WaitForSeconds(0.01f);
                }
            }
            else
            {
                int y =-90;
                while (y < 0)
                {
                    _door.transform.localRotation = Quaternion.Euler(0, y, 0);
                    y++;
                    yield return new WaitForSeconds(0.01f);
                }
            }
            InstanceHandler.Instance.DoorSoundPlayer.PlayCloseMetalDoorSound();
        }
    }
}
