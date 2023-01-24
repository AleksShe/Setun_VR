using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
[AosSdk.Core.Utils.AosObject(name: "Коннект")]
public class ConnectionChecker : AosObjectBase
{
    [AosEvent(name: "Готов к подключению")]
    public event AosEventHandlerWithAttribute OnReadyToAction;
    public UnityAction OnConnectionReady;

    public void OnConnect()
    {
        OnReadyToAction.Invoke("Ready to Action");
        OnConnectionReady?.Invoke();
    }
}
