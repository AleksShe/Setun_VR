using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HelperCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _helperWindow;
    [SerializeField] private GameObject _reactionWindow;

    [SerializeField] private TextMeshProUGUI _helpertext;
    [SerializeField] private TextMeshProUGUI _reactiontext;

    public void EnableHelperWindow(bool value) => _helperWindow.SetActive(value);
    public void EnableReactionWindow(bool value) => _reactionWindow.SetActive(value);
    public void SetHelperText(string text) => _helpertext.text = text;
    public void SetReactionText(string text) => _reactiontext.text = text;
}
