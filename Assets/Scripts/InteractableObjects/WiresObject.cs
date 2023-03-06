using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiresObject : ToolObject
{
    [SerializeField] private GameObject _normalWires;
    [SerializeField] private GameObject _brokenlWires;
    private bool _animated = false;
    public override void PlayToolAnimation()
    {
        StartCoroutine(ChangeWires());
    }
    private IEnumerator ChangeWires()
    {
        if (!_animated)
        {
            InstanceHandler.Instance.MovingButtonsController.HideAllButtons();
            _animated = true;
            int x = 0;
            while (x < 8)
            {
                transform.position += new Vector3(0.03f, 0, 0);
                yield return new WaitForSeconds(0.05f);
                x++;
            }
            _normalWires.SetActive(true);
            _brokenlWires.SetActive(false);
            yield return new WaitForSeconds(0.03f);
            while (x >= 1)
            {
                transform.position -= new Vector3(0.03f, 0, 0);
                yield return new WaitForSeconds(0.05f);
                x--;
            }
            _animated = false;
        }

    }
}
