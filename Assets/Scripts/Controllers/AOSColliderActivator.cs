using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOSColliderActivator : MonoBehaviour
{
    private List<SceneObject> _aosSceneObjects = new List<SceneObject>();
    public bool CanTouch { get; set; } = true;
    public void AddSceneObject(SceneObject obj)
    {
        _aosSceneObjects.Add(obj);
    }
    public void ActivateColliders(string objectName, string text)
    {
        foreach (var sceneObject in _aosSceneObjects)
        {
            if (sceneObject.GetAOSName() == objectName)
            {
                sceneObject.EnableObject(true);
                sceneObject.SetHelperName(text);
            }
        }
    }
    public void DeactivateAllColliders()
    {
        foreach (var sceneObject in _aosSceneObjects)
        {
            sceneObject.EnableObject(false);
        }
    }

}
