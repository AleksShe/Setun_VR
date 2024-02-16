using TMPro;
using UnityEngine;

public abstract class BaseStartScreenView : MonoBehaviour
{
    [SerializeField] protected ModeController ModeController;
    [SerializeField] protected GameObject NextButtonGameObject;
    [Space]
    [SerializeField] protected TextMeshProUGUI HeaderText;
    [SerializeField] protected TextMeshProUGUI CommentText;
    [SerializeField] protected TextMeshProUGUI NextButtonText;

    protected INextButton NextButton;
    protected virtual void Awake()
    {
        NextButton = NextButtonGameObject.GetComponent<INextButton>();
        if (NextButton == null)
        {
            Debug.Log($"You must inherit gameObject {NextButtonGameObject.name} from INextButton");
            return;
        }
        NextButton.NextButtonPressedEvent += OnHideStartScreen;
    }
    public virtual void SetStartScreenText(string headerText, string commentText, string buttonText, NextButtonState state)
    {
        NextButtonGameObject.SetActive(true);
        HeaderText.text = headerText;
        CommentText.text = commentText;
        NextButtonText.text = buttonText;
        NextButton.CurrentState = state;
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
        }
    }
    protected abstract void DisableStartScreen();
  
}
