using AosSdk.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOSObjectsActivator : MonoBehaviour
{
    private List<SceneObject> _aosSceneObjects = new List<SceneObject>();
    private List<PointObject> _aosPointObjects = new List<PointObject>();
    public bool CanTouch { get; set; } = true;
    public void AddSceneObject(SceneObject obj) => _aosSceneObjects.Add(obj);
    public void AddPointObject(PointObject obj) => _aosPointObjects.Add(obj);
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
    public void ActivatePoints(string pointName, string text)
    {
        foreach (var pointObj in _aosPointObjects)
        {
            if (pointObj.GetAOSName() == pointName)
            {
                pointObj.EnableObject(true);
                pointObj.SetPointText(text);
            }
        }
    }
    public void DeactivateAllColliders()
    {
        foreach (var sceneObject in _aosSceneObjects)
            sceneObject.EnableObject(false);
    }
}
