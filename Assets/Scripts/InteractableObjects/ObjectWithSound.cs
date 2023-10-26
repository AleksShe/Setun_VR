using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SceneAosObject))]
[RequireComponent(typeof(AudioSource))]

public class ObjectWithSound : MonoBehaviour
{
    [SerializeField] private bool _withParametr;
    private SceneAosObject _aosObject;
    private AudioSource _audioSource;
    private const string PEN = "pen";

    private void Awake()
    {
        _aosObject = GetComponent<SceneAosObject>();
        _audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        _aosObject.OnClickObject += OnPlaySound;
    }
    private void OnPlaySound(object parameter)
    {
        if(!_withParametr)
        _audioSource.Play();
        else if(_withParametr && parameter.ToString()== PEN)
            _audioSource.Play();
    }
 
 
}
