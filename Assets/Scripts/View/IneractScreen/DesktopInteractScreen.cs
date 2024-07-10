using System;
using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DesktopInteractScreen : BaseInteractScreen
{
    [SerializeField] private GameObject _helper;
    [SerializeField] private GameObject _reaction;
    [SerializeField] private GameObject _timer;
    [SerializeField] private GameObject _location;
    [SerializeField] private GameObject _interactIcons;
    [SerializeField] private CanvasGroupFader _canvasGroup;

    [SerializeField] private TextMeshProUGUI _helperText;
    [SerializeField] private Text _headerStickerText;
    [SerializeField] private Text _stickerText;
    [SerializeField] private Image _stickerImage;
    [SerializeField] private Sprite _stickerSpriteOK;
    [SerializeField] private Sprite _stickerSpriteNotOK;
    [SerializeField] private TextMeshProUGUI _reactionText;
    [SerializeField] private TextMeshProUGUI _locationText;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private BaseActionObject[] _baseActionObjects;
    private Vector3 _helperStartPos;
    private Timer _time = new Timer();
    private void Start()
    {
        _helperStartPos = _helper.transform.position;
    }
    public override void SetHelperText(string helperText) => EnableTextObject(helperText, _helperText, _helper);
    public override void SetLocationText(string locationText) => _locationText.text = locationText;
    public override void EnableHelperObject(bool active) => _helper.SetActive(active);
    public override void EnableLocationObject(bool active) => _location.SetActive(active);
    public override void EnableTimerObject(bool active) => _timer.SetActive(active);
    public override void EnableInteractIcons(bool active) => _interactIcons.SetActive(active);
    public override void SetReactionText(string helperText) => _reactionText.text = helperText;
    public override void EnableReactionObject(bool active) => _reaction.SetActive(active);
    public override void SetHelperTextPosition(VectorHolder newPos)
    {
        if (newPos != null)
            _helper.transform.position = newPos.Position;
        else
            _helper.transform.position = _helperStartPos;
    }

    public override void SetTimerText(string timerText)
    {
        double.TryParse(timerText, out double time);
        _time.TimeChanger(time);
        _timerText.text = _time.GetFormattedTime();
    }
    private void EnableTextObject(string text, TextMeshProUGUI textObject, GameObject obj)
    {
        if (text == null)
        {
            obj.SetActive(false);
            textObject.text = "";
        }
        else
        {
            textObject.text = text;
            obj.SetActive(true);
        }
    }

    public override void EnableActivateActionObject(SceneActionState state)
    {
        var actionObject = _baseActionObjects.FirstOrDefault(o => o.SceneActionState == state);
        if (actionObject != null)
            actionObject.Enable();
    }

    public override void DisableAllActionObjects()
    {
        StartCoroutine(DisableDelay());
    }
    private IEnumerator DisableDelay()
    {
        yield return new WaitForSeconds(0.1f);
        foreach (var baseActionObject in _baseActionObjects)
        {
            if (baseActionObject != null)
                baseActionObject.Disable();
        }
    }
    public override void ShowSticker(string header, string penalty, string text)
    {
        SetSprite(penalty);
        _headerStickerText.text = header;
        if (text != "")
        {
            _stickerText.text = text;
            _stickerText.gameObject.SetActive(true);
        }
        else
        {
            _stickerText.gameObject.SetActive(false);
        }
        _canvasGroup.FadeIn();
        StartCoroutine(HideSticker());
    }

    public IEnumerator HideSticker()
    {
        yield return new WaitForSeconds(1);
        _canvasGroup.FadeOut();
    }
    private void SetSprite(string name)
    {
        if (name == "0")
        {
            _stickerImage.sprite = _stickerSpriteOK;

        }
        else if (name == "1")
        {
            _stickerImage.sprite = _stickerSpriteNotOK;

        }
    }
}
