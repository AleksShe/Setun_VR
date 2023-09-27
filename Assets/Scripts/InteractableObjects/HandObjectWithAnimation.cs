using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandObjectWithAnimation : MonoBehaviour, IHandObject
{
    [SerializeField]private Animator _anim;
   
    public void HandAction() => _anim.SetTrigger("Hand");
    public void PlayBrokenAnimation() => _anim.SetTrigger("Broke");

}
