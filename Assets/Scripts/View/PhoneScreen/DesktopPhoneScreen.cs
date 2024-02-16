using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DesktopPhoneScreen : BasePhoneScreen
{
    [SerializeField] private TextMeshProUGUI _phoneHeader;
    [Space]
    [SerializeField] private TextObjectUi _dialogPrefub;
    [SerializeField] private Transform _dialogParent;
    [Space]
    [SerializeField] private TextObjectUi _buttonPrefub;
    [SerializeField] private Transform _buttonParent;
    [SerializeField] private GameObject _phone;
    [SerializeField] private GameObject _phoneMainScreen;
    [SerializeField] private GameObject _phoneDialogScreen;

    private List<TextObjectUi> _textObjectUis = new List<TextObjectUi>();

    public override void ActivatePhone(bool active)
    {
        _phone.SetActive(active);
    }

    public override void ActivatePhoneDialogScreen(bool active)
    {
        _phoneMainScreen.SetActive(!active);
        _phoneDialogScreen.SetActive(active);
    }

    public override void ActivatePhoneMainScreen(bool active)
    {
        _phoneDialogScreen.SetActive(!active);
        _phoneMainScreen.SetActive(active);
    }
    public override void AddItem(string text, DialogRole role)
    {
        var exist = _textObjectUis.FirstOrDefault(o => o.Text == text);
        if (exist != null)
            return;
        var prefub = Instantiate(_dialogPrefub, _dialogParent);
        if (role == DialogRole.User)
            prefub.SetText(text, TextAlignmentOptions.Right);
        else
            prefub.SetText(text, TextAlignmentOptions.Left);
        _textObjectUis.Add(prefub);
    }
    public override void AddItem(string id, string text)
    {
        Debug.Log("ADD Item");
        var exist = _textObjectUis.FirstOrDefault(o => o.Text == text);
        if (exist != null)
            return;
        var prefub = Instantiate(_buttonPrefub, _buttonParent);
        prefub.SetText(text, TextAlignmentOptions.Center);
        var aosId = prefub.GetComponent<PointUiButton>();
        aosId.SetButtonId(id);
        _textObjectUis.Add(prefub);
    }
    public override void ClearItemsList()
    {
        foreach (var item in _textObjectUis)
        {
            Destroy(item.gameObject);
        }
        _textObjectUis = new List<TextObjectUi>();
    }

    public override void SetPhoneHeader(string text) => _phoneHeader.text = text;
}
