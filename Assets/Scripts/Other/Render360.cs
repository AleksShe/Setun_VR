using AosSdk.Core.Utils;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Render360 : MonoBehaviour
{
    [SerializeField] private InputActionProperty _screenShowAction;
    [SerializeField] private bool _format;
    [SerializeField] private int _imageSize;
    [SerializeField] private string _fileName;

    private void OnEnable()
    {
        _screenShowAction.action.performed += OnScreenShot;
    }
    private void OnDisable()
    {
        _screenShowAction.action.performed -= OnScreenShot;
    }
    private void OnScreenShot(InputAction.CallbackContext c)
    {
        int rnd = UnityEngine.Random.Range(0, 800000);
        byte[] bytes = I360Render.Capture(_imageSize, _format);
        if (bytes != null)
        {
            string path = Path.Combine(Application.persistentDataPath, _fileName + rnd + (_format ? ".jpeg" : ".png"));
            File.WriteAllBytes(path, bytes);
            Debug.Log("360 render saved to " + path);
        }
    }

}
