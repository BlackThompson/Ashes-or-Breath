using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SplashController : MonoBehaviour
{
    public Image logoImage;
    public float fadeDuration = 1.5f;
    public float holdDuration = 2.0f;
    public string nextSceneName = "Scene/Museum";

    private void Start()
    {
        StartCoroutine(PlaySplashSequence());
    }

    IEnumerator PlaySplashSequence()
    {
        // 初始透明
        Color color = logoImage.color;
        color.a = 0f;
        logoImage.color = color;

        // 淡入
        yield return StartCoroutine(FadeLogo(0f, 1f, fadeDuration));

        // 停留
        yield return new WaitForSeconds(holdDuration);

        // 淡出
        yield return StartCoroutine(FadeLogo(1f, 0f, fadeDuration));

        // 加载主场景
        SceneManager.LoadScene(nextSceneName);
    }

    IEnumerator FadeLogo(float from, float to, float duration)
    {
        float timer = 0f;
        Color color = logoImage.color;

        while (timer < duration)
        {
            float alpha = Mathf.Lerp(from, to, timer / duration);
            logoImage.color = new Color(color.r, color.g, color.b, alpha);
            timer += Time.deltaTime;
            yield return null;
        }

        logoImage.color = new Color(color.r, color.g, color.b, to);
    }
}
