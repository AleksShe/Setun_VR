using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeController : MonoBehaviour
{
    [SerializeField] private GameObject _desktopPlayer;
    [SerializeField] private GameObject _vrPlayer;
    [SerializeField] private GameObject _desktopPlayerEventSystem;
    [SerializeField] private GameObject _vrEventSystem;

    private void Awake()
    {
        if(!_desktopPlayer.activeSelf)
            _desktopPlayerEventSystem.SetActive(false);
        else _vrEventSystem.SetActive(false);
    }
    public Transform GetPlayerTransform()
    {
        if (!_desktopPlayer.activeSelf)
        {
            return _vrPlayer.transform;
        }
        else return _desktopPlayer.transform;
    }
    public bool VrMode => !_desktopPlayer.activeSelf;
}
