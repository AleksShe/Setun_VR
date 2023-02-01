using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovingButtonsController : MonoBehaviour
{
    public UnityAction ButtonsPositionChanged;
    [HideInInspector] public string ObjectHelperName { get; set; }
    [HideInInspector] public string ObjectName { get; set; }

    public SceneObject CurrentBaseObject { get; set; }

    //private IScriptableAnimationObject _tempRepairableObject;
    //private IScriptableAnimationObject _tempPushableObject;

    [SerializeField] private GameObject _eyeButton;
    [SerializeField] private GameObject _toolButton;
    [SerializeField] private GameObject _toolButton_1;
    [SerializeField] private GameObject _handButton;
    [SerializeField] private GameObject _handButton_1;
    [SerializeField] private GameObject _handButton_2;
    [SerializeField] private GameObject _penButton;

    public void SetCurrentBaseObjectAndMovingButtonsPosition(Vector3 position, SceneObject obj)
    {
        HideAllButtons();
        transform.position = position;
        CurrentBaseObject = obj;
    }
    public void ShowWatchButton()
    {
        _eyeButton.SetActive(true);
    }
    public void ShowToolButton()
    {
        _toolButton.SetActive(true);
    }
    public void ShowTool1Button()
    {
        _toolButton_1.SetActive(true);
    }
    public void ShowHandButton()
    {
        _handButton.SetActive(true);
    }
    public void ShowHand1Button()
    {
        _handButton_1.SetActive(true);
    }
    public void ShowHand2Button()
    {
        _handButton_2.SetActive(true);
    }
    public void ShowPenButton()
    {
        _penButton.SetActive(true);
    }
    public void HideAllButtons()
    {
        _eyeButton.SetActive(false);
        _toolButton.SetActive(false);
        _handButton.SetActive(false);
        _handButton_1.SetActive(false);
        _handButton_2.SetActive(false);
        _penButton.SetActive(false);
        _toolButton_1.SetActive(false);
        ButtonsPositionChanged?.Invoke();
    }
    public void SetWatchButtonText(string text)
    {
        _eyeButton.TryGetComponent(out MovingButton movingButton);
        movingButton.SetActionText(HtmlToText.Instance.HTMLToTextReplace(text));
    }
    public void SetToolButtonText(string text)
    {
        _toolButton.TryGetComponent(out MovingButton movingButton);
        movingButton.SetActionText(HtmlToText.Instance.HTMLToTextReplace(text));
    }
    public void SetTool1ButtonText(string text)
    {
        _toolButton_1.TryGetComponent(out MovingButton movingButton);
        movingButton.SetActionText(HtmlToText.Instance.HTMLToTextReplace(text));
    }
    public void SetHandButtonText(string text)
    {
        _handButton.TryGetComponent(out MovingButton movingButton);
        movingButton.SetActionText(HtmlToText.Instance.HTMLToTextReplace(text));
    }
    public void SetHand1ButtonText(string text)
    {
        _handButton_1.TryGetComponent(out MovingButton movingButton);
        movingButton.SetActionText(HtmlToText.Instance.HTMLToTextReplace(text));
    }
    public void SetHand2ButtonText(string text)
    {
        _handButton_2.TryGetComponent(out MovingButton movingButton);
        movingButton.SetActionText(HtmlToText.Instance.HTMLToTextReplace(text));
    }
    public void SetPenButtonText(string text)
    {
        _penButton.TryGetComponent(out MovingButton movingButton);
        movingButton.SetActionText(HtmlToText.Instance.HTMLToTextReplace(text));
    }
    //public void SetToolObject(RepairableObject obj)
    //{
    //    _tempRepairableObject = obj;
    //}
    //public void PlayToolAnimation()
    //{
    //    if (_tempRepairableObject != null)
    //        _tempRepairableObject.PlayScritableAnimtaion();
    //}
    //public void SetPushObject(PushableObject obj)
    //{
    //    _tempPushableObject = obj;
    //}
    //public void PlayPushAnimation()
    //{
    //    if (_tempPushableObject != null)
    //        _tempPushableObject.PlayScritableAnimtaion();
    //}

}
