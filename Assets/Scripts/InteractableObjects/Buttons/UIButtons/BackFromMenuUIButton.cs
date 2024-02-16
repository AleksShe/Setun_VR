using UnityEngine;
public class BackFromMenuUIButton : BaseUIButton
{
    [SerializeField] private EscActionObject _escObject;
    protected override void Click()=> _escObject.Activate();
}
