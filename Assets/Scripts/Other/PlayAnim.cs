using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnim : MonoBehaviour
{
    private Animator _anim;
    void Start()
    {
        _anim = GetComponent<Animator>();
        StartCoroutine(Temp());

    }
    private IEnumerator Temp()
    {
        yield return new WaitForSeconds(3);
        _anim.SetTrigger("Broke");
    }
}
