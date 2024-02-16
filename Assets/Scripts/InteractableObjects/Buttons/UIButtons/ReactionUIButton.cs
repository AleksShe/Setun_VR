using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ReactionUIButton : BaseUIButton
{
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private Image _currentSprite;
    [SerializeField] private TextMeshProUGUI _reactionText;

    public static Action<ButtonActionName> ActionWithObjectEvent;
    private ButtonActionName _currentActionName;
    private StringParser _stringParser = new StringParser();
    private SceneAosObject _sceneAosObject;

    public ButtonActionName ButtonActionName => _currentActionName;
    public void Init(ButtonActionName buttonActionName, string text, SceneAosObject sceneAosObject)
    {
        _currentActionName = buttonActionName;
        var sprite = GetSpriteByName();
        if (sprite != null)
        {
            _currentSprite.sprite = sprite;
        }
        _reactionText.text = text;
        _sceneAosObject = sceneAosObject;
    }
    protected override void Click()
    {
        if (_sceneAosObject == null)
            return;
        var actionText = _stringParser.GetStringFromEnum(_currentActionName);
        _sceneAosObject.ActionWithObject(actionText);
        ActionWithObjectEvent?.Invoke(_currentActionName);
    }
    private Sprite GetSpriteByName()
    {
        foreach (var sprite in _sprites)
        {
            var actionText = _stringParser.GetStringFromEnum(_currentActionName);
            var cleanString = _stringParser.GetStringWithoutNumbers(actionText);
            if (sprite.name == cleanString)
                return sprite;
        }
        return null;
    }
}
