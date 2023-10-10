using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DesktopCanvasObjectsHolder : MonoBehaviour
{
    [SerializeField] private TextObjectUi _prefub;
    [SerializeField] private Transform _parent;
    [SerializeField] private UIMenuButton _button;
    [SerializeField] private Scrollbar _sideScroll;

    private List<TextObjectUi> _textObjectUis = new List<TextObjectUi>();
    private void Start()
    {
        _button.ButtonClickedEvent += OnClearItemsList;
    }
    public void AddItem(string text,DialogRole role)
    {
        var exist = _textObjectUis.FirstOrDefault(o => o.Text == text);
        if (exist != null)
            return;
        var prefub = Instantiate(_prefub, _parent);
        if(role==DialogRole.User)
        prefub.SetText(text, TextAlignmentOptions.Right);
        else
            prefub.SetText(text, TextAlignmentOptions.Left);
        _textObjectUis.Add(prefub);
        _sideScroll.value = 1;
    }
    public void AddItem(string id, string text)
    {
        var exist = _textObjectUis.FirstOrDefault(o => o.Text == text);
        if (exist != null)
            return;
        var prefub = Instantiate(_prefub, _parent);
        prefub.SetText(text,TextAlignmentOptions.Center);
        var aosId = prefub.GetComponent<PointUiButton>();
        aosId.SetButtonId(id);
        _textObjectUis.Add(prefub);
        _sideScroll.value = 1;
    }
    private void OnClearItemsList()
    {
        foreach (var item in _textObjectUis)
        {
            Destroy(item.gameObject);
        }
        _textObjectUis = new List<TextObjectUi>();
    }
}
