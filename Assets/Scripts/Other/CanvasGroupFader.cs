using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class CanvasGroupFader : MonoBehaviour
{
    [SerializeField][Range(0.0f, 1.0f)] private float _fadeDuration = 1.0f;
    [SerializeField][Range(0.0f, 1.0f)] private float _delayDuration = 0.0f;

    private Coroutine _currentCoroutine;
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void FadeIn()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(FadeCanvasGroup(1, 1));
    }

    public void FadeOut()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(FadeCanvasGroup(1, 0));
    }

    private IEnumerator FadeCanvasGroup(float start, float end)
    {
        if (_delayDuration > 0)
        {
            yield return new WaitForSeconds(_delayDuration);
        }

        float elapsedTime = 0;
        while (elapsedTime < _fadeDuration)
        {
            _canvasGroup.alpha = Mathf.Lerp(start, end, elapsedTime / _fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _canvasGroup.alpha = end;
    }
}