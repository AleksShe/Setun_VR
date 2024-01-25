using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class MenuImageAnimation : MonoBehaviour
{
    [SerializeField] private GameObject _loadImage;
    private void Start()
    {
        StartCoroutine(RotateImage());
    }
    private IEnumerator RotateImage()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);
            _loadImage.transform.Rotate(0, 0,-50);
        }
       
    }
}
