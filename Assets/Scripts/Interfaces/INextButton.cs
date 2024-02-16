public delegate void NextButtonPressed(string name);
public interface INextButton
{
    public event NextButtonPressed NextButtonPressedEvent;
    public NextButtonState CurrentState { get; set; }
    void ClickNextButton();
}
