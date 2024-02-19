using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UbpObject : ToolObject
{
    [SerializeField] private GameObject _ubp;
   
    private bool _animated = false;
    public override void PlayToolAnimation() => StartCoroutine(ChangeUbp());
    private IEnumerator ChangeUbp()
    {
        if (!_animated)
        {
            _animated = true;
            int x = 0;
            while (x < 12)
            {
                transform.position += new Vector3(0.03f, 0, 0);
                yield return new WaitForSeconds(0.05f);
                x++;
            }
            var mesh = GetComponent<MeshRenderer>();
            mesh.enabled = false;
            
            MeshRenderer[] rs = GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer r in rs)
                r.enabled = false;
            yield return new WaitForSeconds(0.5f);
            mesh.enabled = true;
            foreach (MeshRenderer r in rs)
                r.enabled = true;

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
