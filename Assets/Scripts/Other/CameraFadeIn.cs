using AosSdk.Core.PlayerModule;
using System.Collections;
using UnityEngine;

public class CameraFadeIn : MonoBehaviour
{
    public void StartFade()
    {
        Player.Instance.FadeIn(1f, true);
        StartCoroutine(FadeDelay());
    }
    private IEnumerator FadeDelay()
    {
        yield return new WaitForSeconds(0.2f);
        Player.Instance.FadeOut(1f, false);
    }
}
