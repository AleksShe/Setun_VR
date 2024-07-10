using AosSdk.Core.PlayerModule.Pointer;
using AosSdk.Core.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointObject : BaseObject
{
    [SerializeField] private TextMeshProUGUI _pointText;
    private Button _button;
    private bool _uiPointer;
    private void Start()
    {
        SceneObjectsHolder.Instance.AddSceneObject(this);
        _button = GetComponent<Button>();
        if (_button != null)
        {
            _button.onClick.AddListener(() => SendPointObj());
            _uiPointer = true;
        }
        EnableObject(false);
    }
   
    public void SetPointText(string text) => _pointText.text = text;
    public override void EnableObject(bool value)
    {
        GetComponent<Image>().enabled = value;
        _pointText.enabled = value;
        if (_uiPointer)
            _button.enabled = value;
        else
            GetComponent<Collider>().enabled = value;
    }

    private void SendPointObj()
    {
        var pointObject = new JsonAosObject();
        pointObject.castedToStringAttribute = name;
        pointObject.objectId = name;
        WebSocketWrapper.Instance.DoSendMessage(pointObject);
    }
}
