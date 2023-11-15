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
                renderer.material.EnableKeyword("_EMISSION");
                renderer.material.SetColor("_EmissionColor", Color.white);
                renderer.material.color = Color.white;
            }
            else
            {
                renderer.material.SetColor("_EmissionColor", Color.black);
                renderer.material.color = _color;
            }
        }
    }
}
