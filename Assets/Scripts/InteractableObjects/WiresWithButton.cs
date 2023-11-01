using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiresWithButton : ObjectWithButton
{
    [SerializeField] private Renderer[] _renderers;
    protected override void EnableHighlight(bool value)
    {
      HighlightMaterials(value);
    }
    private void HighlightMaterials(bool value)
    {
        foreach (var renderer in _renderers)
        {
            if (value)
                renderer.material.color *= 2;
            else
                renderer.material.color /= 2;
        }

    }
}
