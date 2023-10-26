using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip _openMetalDoorSound;
    [SerializeField] private AudioClip _closeMetalDoorSound;
    private AudioSource _audioSource;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void PlayOpenMetalDoorSound() => _audioSource.PlayOneShot(_openMetalDoorSound);
    public void PlayCloseMetalDoorSound() => _audioSource.PlayOneShot(_closeMetalDoorSound);
}
