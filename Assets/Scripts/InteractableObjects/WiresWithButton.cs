using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiresWithButton : ObjectWithButton
{
    [SerializeField] private Renderer[] _renderers;
    [SerializeField] private Color _color;
    protected override void EnableHighlight(bool value)
    {
        HighlightMaterials(value);
    }
    private void HighlightMaterials(bool value)
    {
        foreach (var renderer in _renderers)
        {
            if (value)
            {
                renderer.material.color *= 2.5f;
                renderer.material.color = Color.white;
            }
            else
            {
                renderer.material.color /= 2.5f;
                renderer.material.color = _color;
            }
        }
    }
}
