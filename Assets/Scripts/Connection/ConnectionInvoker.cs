using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionInvoker : MonoBehaviour
{
    [SerializeField] private WebSocketWrapper _wrapper;
    [SerializeField] private ConnectionChecker _connectionChecker;

    private void OnEnable()
    {
        _wrapper.OnClientConnected += OnReadyToConnect;
    }
    private void OnDisable()
    {
        _wrapper.OnClientConnected -= OnReadyToConnect;
    }
    private void OnReadyToConnect()
    {
        _connectionChecker.OnConnect();
    }
}
