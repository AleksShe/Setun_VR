using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitDoorAnimationObject : ObjectWithAnimation
{
    [SerializeField] private GameObject _door1;
    [SerializeField] private GameObject _door2;

    public override void PlayScriptableAnimationOpen() => StartCoroutine(RotateDoor(true));
    public override void PlayScriptableAnimationClose() => StartCoroutine(RotateDoor(false));
    private IEnumerator RotateDoor(bool value)
    {
        GetComponent<Collider>().enabled = false;
        if (value)
        {
            int y = 0;
            while (y < 90)
            {
                _door1.transform.localRotation = Quaternion.Euler(0, y, 0);
                _door2.transform.localRotation = Quaternion.Euler(0, y, 0);
                y++;
                yield return new WaitForSeconds(0.01f);
            }
        }
        else if (!value)
        {
            int y = 90;
            while (y > 0)
            {
                _door1.transform.localRotation = Quaternion.Euler(0, y, 0);
                _door2.transform.localRotation = Quaternion.Euler(0, y, 0);
                y--;
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}
