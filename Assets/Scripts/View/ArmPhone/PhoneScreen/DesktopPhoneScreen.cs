using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DesktopPhoneScreen : BasePhoneScreen
{
    [SerializeField] private TextMeshProUGUI _phoneHeader;
    [Space]
    [SerializeField] private TextUiPhone _dialogPrefub;
    [SerializeField] private TextUiPhone _userPrefub;
    [SerializeField] private Transform _dialogParent;
    [Space]
    [SerializeField] private TextObjectUi _buttonPrefub;
    [SerializeField] private Transform _buttonParent;
    [SerializeField] private GameObject _phoneMainScreen;
    [SerializeField] private GameObject _phoneDialogScreen;
    private List<TextObjectUi> _textObjectUis = new List<TextObjectUi>();
    private List<TextUiPhone> _textObjectUis2 = new List<TextUiPhone>();

    public override void ActivateScreen(bool active)
    {
        Screen.SetActive(active);
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
        var exist = _textObjectUis2.FirstOrDefault(o => o.Text == text);
        if (exist != null)
            return;
       
        if (role == DialogRole.User)
        {
            var prefub = Instantiate(_userPrefub, _dialogParent);
            prefub.SetText(text);
            _textObjectUis2.Add(prefub);
        }

        else
        {
            var prefub = Instantiate(_dialogPrefub, _dialogParent);
            prefub.SetText(text);
            _textObjectUis2.Add(prefub);
        }
           
       
    }
    public override void AddItem(string id, string text)
    {
        var exist = _textObjectUis.FirstOrDefault(o => o.Text == text);
        if (exist != null)
            return;
        var prefub = Instantiate(_buttonPrefub, _buttonParent);
        prefub.SetText(text);   
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
        foreach (var item in _textObjectUis2)
        {
            Destroy(item.gameObject);
        }
        _textObjectUis2 = new List<TextUiPhone>();
    }

    public override void SetPhoneHeader(string text) => _phoneHeader.text = text;
}
