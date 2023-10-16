using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectEnabler : MonoBehaviour
{
    [SerializeField] private GameObject _obj;
    public void EnableObject(bool value)=>_obj.SetActive(value);
}
