using AosSdk.Core.PlayerModule;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseStartScreenView : MonoBehaviour
{
    [SerializeField] protected ModeController ModeController;
    [SerializeField] protected GameObject NextButtonGameObject;
    [SerializeField] protected GameObject LoadImage;
    [SerializeField] protected GameObject CatoLogoImage;
    [SerializeField] protected GameObject LineImage;
    [SerializeField] protected GameObject GuideButton;
    [SerializeField] protected GameObject MidleExitButton;
    [SerializeField] protected GameObject LeftExitButton;
    [SerializeField] protected NextUIButton _nextUIButton;
    [Space]
    [SerializeField] protected Text HeaderText;
    [SerializeField] protected Text CommentText;
    [SerializeField] protected Text HeaderFaultText;
    [SerializeField] protected Text CommentFaultText;

    private void Start()
    {
        _nextUIButton.NextButtonPressedEvent += OnHideStartScreen;
        Cursor.visible = true;
    }  
    public virtual void SetStartScreenText(string headerText, string commentText, string headerFaultText, string commentFaultText)
    {
        CommentText.alignment = TextAnchor.MiddleLeft;
        LoadImage.SetActive(false);
        CatoLogoImage.SetActive(true);
        GuideButton.SetActive(true);
        NextButtonGameObject.SetActive(true);
        MidleExitButton.SetActive(false);
        LeftExitButton.SetActive(true);

        HeaderText.text = headerText;
        CommentText.text = commentText;
        HeaderFaultText.text = headerFaultText;
        CommentFaultText.text = commentFaultText;

    }
    protected virtual void OnHideStartScreen(string text)
    {      
        if (text == "start")
        {
            DisableStartScreen();
            ModeController.CurrentInteractScreen.EnableAllHelperObjects(true);
            ModeController.CurrentInteractScreen.EnableLocationObject(true);
            ModeController.CurrentInteractScreen.EnableTimerObject(true);
            ModeController.CurrentMenuController.CanTeleport = true;
            LineImage.SetActive(true);
        }
    }
    protected abstract void DisableStartScreen();
  
}
