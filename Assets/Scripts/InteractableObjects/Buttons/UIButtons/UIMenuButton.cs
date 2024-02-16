using UnityEngine;

public class UIMenuButton : BaseUIButton
{
    [SerializeField] private GameObject _showScreen;
    [SerializeField] private GameObject _hideScreen;
    protected override void Click()
    {
        if (_showScreen != null)
            _showScreen.SetActive(true);
        if (_hideScreen != null)
        {
            _hideScreen.SetActive(false);
        }
    }
}
