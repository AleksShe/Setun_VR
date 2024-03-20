using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ImageChanger : MonoBehaviour
{
    [SerializeField] private Sprite[] _guideImages;
    [SerializeField] private Button _nextSlide;
    [SerializeField] private Button _backSlide;
    [SerializeField] private Text _counterText;
    private int _currentSlide = 0;
    private int _lenght;
    
    private void Start()
    {
       _lenght =_guideImages.Length;
       
            _nextSlide.onClick.AddListener(() => OnChangeSprite(true));
        _backSlide.onClick.AddListener(() => OnChangeSprite(false));
        SetCounter();
    }
    private void OnChangeSprite(bool value)
    {
        if(value)
        {
            _currentSlide++;
        }
        else
        {
            _currentSlide--;
        }
        
        if (_currentSlide <= 0) {
            _currentSlide = 0;
            _backSlide.enabled = false;
            _backSlide.image.color = new Color(1, 1, 1, 0.25f);
        }
        else
        {
            _backSlide.enabled = true;
            _backSlide.image.color = new Color(1, 1, 1,1);
        }
        if(_currentSlide >= _lenght -1)
        {
            _currentSlide = _lenght -1;
            _nextSlide.enabled = false;
            _nextSlide.image.color = new Color(1, 1, 1, 0.25f);
        }
        else
        {
            _nextSlide.enabled = true;
            _nextSlide.image.color = new Color(1, 1, 1, 1);
        }
        GetComponent<Image>().sprite = _guideImages[_currentSlide];
        SetCounter();
    }
    private void SetCounter()
    {
        _counterText.text = $"{_currentSlide+1}/{_lenght}";
    }


}
