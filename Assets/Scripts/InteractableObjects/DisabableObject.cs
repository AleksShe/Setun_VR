using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisabableObject : MonoBehaviour, IHandObject
{
    public void HandAction()
    {
        InstanceHandler.Instance.MovingButtonsController.HideAllButtons();
      gameObject.SetActive(false);
    }
}
