using System.Collections;
using UnityEngine;
using TMPro;

public class ButtonInteraction : MonoBehaviour
{
    [Header("UI Components")]
    public TMP_Text messageText;
    public CanvasGroup canvasGroup;

    [Header("Spawn Object")]
    public GameObject cubePrefab;
    private GameObject spawnedCube;

    private bool triggered = false;

    public void OnButtonClick()
    {
        if (triggered) return;
        triggered = true;
        StartCoroutine(RunInteractionSequence());
    }

    IEnumerator RunInteractionSequence()
    {
        // 显示第一段文字 + 淡入
        messageText.text = "Touch Sphere";
        canvasGroup.alpha = 0;
        canvasGroup.gameObject.SetActive(true);
        yield return StartCoroutine(FadeIn(canvasGroup, 1f));

        // 生成正方体
        Vector3 spawnPos = Camera.main.transform.position + Camera.main.transform.forward * 1.5f + Vector3.down * 0.3f;
        spawnedCube = Instantiate(cubePrefab, spawnPos, Quaternion.identity);

        // 等待 10 秒
        yield return new WaitForSeconds(10f);

        // 销毁正方体 + 淡出文字
        Destroy(spawnedCube);
        yield return StartCoroutine(FadeOut(canvasGroup, 1f));

        // 替换文字并再淡入
        messageText.text = "Finish Touching";
        yield return StartCoroutine(FadeIn(canvasGroup, 1f));
    }

    IEnumerator FadeIn(CanvasGroup group, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            group.alpha = Mathf.Clamp01(elapsed / duration);
            yield return null;
        }
    }

    IEnumerator FadeOut(CanvasGroup group, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            group.alpha = 1f - Mathf.Clamp01(elapsed / duration);
            yield return null;
        }
    }
}
