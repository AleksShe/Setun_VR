using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]
public class UIButtonColorChanger : BaseUIColorChanger
{
    [SerializeField] private Image[] _backgroundImages;
    [SerializeField] private TextMeshProUGUI[] _texts;
    [SerializeField] private Image[] _icons;

    private Color _disbaledImageColor = new Color(0, 0, 0, 0.3f);
    private Color _activeImageColor = new Color(0, 0, 0, 0.7f);
    private Color _enabledImageColor = new Color(0.3254902f, 0.7215686f, 0.5921569f, 0.7f);
    private Color _hoveredImageColor = new Color(0.75f, 0.75f, 0.75f, 1f);
    private Color _activeIconColor = new Color(1, 1, 1, 1f);
    private Color _disbaledIconColor = new Color(1, 1, 1, 0.3f);

    public override void DeactivateState()
    {
        if (!CanChangeState)
            return;
        SetImageColor(_backgroundImages, _disbaledImageColor);
        SetImageColor(_icons, _disbaledIconColor);
        SettextColor(_texts, _disbaledIconColor);
    }
    public override void EnabledState()
    {
        if (!CanChangeState)
            return;
        SetImageColor(_backgroundImages, _enabledImageColor);
        SetImageColor(_icons, _activeIconColor);
        SettextColor(_texts, _activeIconColor);
    }
    public override void ActivateState()
    {
        if (!CanChangeState)
            return;
        SetImageColor(_backgroundImages, _activeImageColor);
        SetImageColor(_icons, _activeIconColor);
        SettextColor(_texts, _activeIconColor);
    }
    private void SetImageColor(Image[] images, Color newColor)
    {
        foreach (Image image in images)
            image.color = newColor;
    }
    private void SettextColor(TextMeshProUGUI[] texts, Color newColor)
    {
        foreach (TextMeshProUGUI text in texts)
            text.color = newColor;
    }
    public override void HoveredState()
    {
        if (!CanChangeState)
            return;
        SetImageColor(_backgroundImages, _hoveredImageColor);
        SetImageColor(_icons, _activeIconColor);
        SettextColor(_texts, _activeIconColor);
    }
}
