using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ampermetr : MonoBehaviour
{
    [SerializeField] private GameObject _ampermetr;
    [SerializeField] private GameObject _strelka;
    public void EnableAmper(bool value, Transform position)
    {
        if (value)
        {
            transform.position = position.position;
            transform.rotation= position.rotation;
            _ampermetr.SetActive(value);
            _strelka.SetActive(value);  
        }
        else
        {
            DisableAmper();
        }
    }
    public void DisableAmper()
    {
        _ampermetr.SetActive(false);
        _strelka.SetActive(false);
    }
}
