using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorAnimation : ObjectWithAnimation
{
   [SerializeField] private Animator _anim;

    public override void PlayScriptableAnimationOpen() => _anim.SetTrigger("Open");
    public override void PlayScriptableAnimationClose() => _anim.SetTrigger("Close");
 
}
