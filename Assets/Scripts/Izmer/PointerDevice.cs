using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerDevice : MonoBehaviour
{
    [SerializeField] private float minValue;
    [SerializeField] private float maxValue;
    [Space] [SerializeField] private float divisionValue;
    [SerializeField] private Transform arrowTransform;
    [SerializeField] private ArrowRotationAxis arrowRotationAxis;


    private enum ArrowRotationAxis
    {
        X,
        Y,
        Z
    }

    public string SetValue(float value)
    {
        var targetRotation = arrowRotationAxis switch
        {
            ArrowRotationAxis.X => Vector3.right,
            ArrowRotationAxis.Y => Vector3.up,
            ArrowRotationAxis.Z => Vector3.forward,
            _ => throw new ArgumentOutOfRangeException()
        };

        string retVal = "HIGH";
        // value = Mathf.Clamp(value, minValue, maxValue);
        if (value < 0)
        {
            if (value > -1 * maxValue)
                targetRotation *= divisionValue * -0.02f;
            else
                targetRotation *= divisionValue * -0.04f;
            retVal = "NEGOVERBOUND";
        }
        else if (value > maxValue)
        {
            if (value >= 2 * maxValue)
                targetRotation *= divisionValue * maxValue * 1.04f;
            else
                targetRotation *= divisionValue * maxValue * 1.02f;
            retVal = "POSOVERBOUND";
        }
        else
            targetRotation *= divisionValue * value;
    
        targetRotation += new Vector3(0, -55, 0);
        Debug.Log(targetRotation + "Rotation     " + value + " value        " + divisionValue + " Division");

        arrowTransform.localRotation = Quaternion.Euler(targetRotation);
        return retVal;
    }
    public void SetMinValue(float min)
    {
        minValue = min;
    }
    public void SetMaxValue(float max)
    {
        maxValue = max;
        SetDivisionValue();
    }
    private void SetDivisionValue()
    {
        divisionValue = 108/ maxValue;
    }
    public float GetMaxValue()
    {
        return maxValue;
    }

}
