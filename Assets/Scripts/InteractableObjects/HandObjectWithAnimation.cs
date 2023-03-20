using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandObjectWithAnimation : MonoBehaviour, IHandObject
{
    private Animator _anim;
    private void Start()
    {
        _anim = GetComponent<Animator>();
    }
    public void HandAction()
    {
        _anim.SetTrigger("hand");
    }
    public void PlayBrokenAnimation()
    {
        _anim.SetTrigger("broke");
    }
}
