using UnityEngine;
using UnityEngine.EventSystems;
[RequireComponent(typeof(BaseUIColorChanger))]

public class UIButtonWithColorChanger : BaseUIButton
{
    private BaseUIColorChanger _baseUiColorChanger;
    public BaseUIColorChanger BaseUIColorChanger => _baseUiColorChanger;
    protected override void Start()
    {
        base.Start();
        _baseUiColorChanger = GetComponent<BaseUIColorChanger>();
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
        _baseUiColorChanger.HoveredState();
    }
    public override void OnPointerExit(PointerEventData eventData)
    {
        _baseUiColorChanger.ActivateState();
    }
}
