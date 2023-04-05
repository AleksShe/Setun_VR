using AosSdk.Core.PlayerModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMove : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(StopMoving());
    }
    public IEnumerator StopMoving()
    {
        yield return new WaitForSeconds(0.03f);
        Player.Instance.CanMove= false;
    }
}
