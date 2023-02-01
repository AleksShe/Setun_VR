using System.Collections;
using AosSdk.Core.Interaction.Interfaces;
using AosSdk.Core.Utils;
using UnityEngine;
using UnityEngine.Events;

[AosSdk.Core.Utils.AosObject(name: "Щуп")]
public class ShupController : AosObjectBase
{
    public UnityAction<string> SetMeasureTextEvent;

    [SerializeField] private GameObject _redShup;
    [SerializeField] private GameObject _blackShup;
    [SerializeField] private MeasureController _measureController;

    private bool _firstMeasure = false;
    public string measureText;

    [AosAction(name: "Измерение точки")]
    public string SetShupPosition([AosParameter("Позиция щупа и название точки измерения")]Transform newPos, string text)
    {
        if (!_firstMeasure)
        {
            if (_redShup.transform.position != newPos.position && _blackShup.transform.position != newPos.position)
            {
                _redShup.transform.position = newPos.position;
                _redShup.transform.rotation = newPos.rotation;
                _redShup.transform.rotation *=Quaternion.Euler(-90, 0, 0);
                _firstMeasure = true;
                measureText = text;
                SetMeasureTextEvent?.Invoke(measureText);
                _measureController.SetRedText(measureText);
            }
            else if (_redShup.transform.position == newPos.position)
            {
                _redShup.transform.position = Vector3.zero;
                _measureController.SetRedText(null);
            }
            else if (_blackShup.transform.position == newPos.position)
            {
                _blackShup.transform.position = Vector3.zero;
                _measureController.SetBlackText(null);
                _firstMeasure = true;
            }
        }
        else if (_firstMeasure)
        {
            if (_redShup.transform.position != newPos.position && _blackShup.transform.position != newPos.position)
            {
                _blackShup.transform.position = newPos.position;
                _blackShup.transform.rotation = newPos.rotation;
                _blackShup.transform.rotation *= Quaternion.Euler(-90, 0, 0);
                _firstMeasure = false;
                measureText = text;
                SetMeasureTextEvent?.Invoke(measureText);
                _measureController.SetBlackText(measureText);
            }

            else if (_blackShup.transform.position == newPos.position)
            {
                _blackShup.transform.position = Vector3.zero;
                _measureController.SetBlackText(null);
            }
            else if (_redShup.transform.position == newPos.position)
            {
                _redShup.transform.position = Vector3.zero;
                _measureController.SetRedText(null);
                _firstMeasure = false;
            }
        }
        if (_redShup.transform.position == Vector3.zero && _blackShup.transform.position == Vector3.zero)
        {
            _firstMeasure = false;
            _measureController.SetRedText(null);
            _measureController.SetBlackText(null);
        }
        return measureText;
    }

  public void ResetShupPosition()
    {
        _redShup.transform.position = Vector3.zero;
        _blackShup.transform.position = Vector3.zero;
        measureText = "";
        SetMeasureTextEvent?.Invoke("");
        _measureController.SetRedText(null);
        _measureController.SetBlackText(null);
        _firstMeasure = false;
    }
}
