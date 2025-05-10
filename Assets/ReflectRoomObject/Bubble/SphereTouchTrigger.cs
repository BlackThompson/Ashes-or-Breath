using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class SphereTouchTrigger : MonoBehaviour
{
    public GameObject touchImage;
    public TMP_Text touchText;
    public Sprite displaySprite;
    public float fadeDuration = 1.5f;

    [Header("Text From File")]
    public TextAsset textFile;

    private string displayText;
    private bool isProcessing = false;

    public void OnTouch()
    {
        if (isProcessing || TouchManager.Instance.IsBusy) return;

        LoadTextFromFile();
        StartCoroutine(HandleTouch());
    }

    private void LoadTextFromFile()
    {
        displayText = textFile != null ? textFile.text : "[Missing Text]";
    }

    private IEnumerator HandleTouch()
    {
        isProcessing = true;
        TouchManager.Instance.SetBusy(true);

        
        // 淡入
        CanvasGroup imgGroup = touchImage.GetComponent<CanvasGroup>();
        CanvasGroup textGroup = touchText.GetComponent<CanvasGroup>();
        
        // 设置图片
        touchImage.GetComponent<Image>().sprite = displaySprite;

        // 设置文字内容并启用
        touchText.text = displayText;

        // 确保初始为透明
        imgGroup.alpha = 0f;
        textGroup.alpha = 0f;

        // 确保对象激活
        touchImage.SetActive(true);
        touchText.gameObject.SetActive(true);

        yield return StartCoroutine(FadeCanvasGroup(imgGroup, 0f, 1f, fadeDuration));
        yield return StartCoroutine(FadeCanvasGroup(textGroup, 0f, 1f, fadeDuration));

        // 等待展示时间
        yield return new WaitForSeconds(10f);

        // 淡出
        yield return StartCoroutine(FadeCanvasGroup(imgGroup, 1f, 0f, fadeDuration));
        yield return StartCoroutine(FadeCanvasGroup(textGroup, 1f, 0f, fadeDuration));

        // 隐藏对象
        touchImage.SetActive(false);
        touchText.gameObject.SetActive(false);

        TouchManager.Instance.SetBusy(false);
        isProcessing = false;
    }

    private IEnumerator FadeCanvasGroup(CanvasGroup cg, float from, float to, float duration)
    {
        float time = 0f;
        cg.alpha = from;

        while (time < duration)
        {
            cg.alpha = Mathf.Lerp(from, to, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        cg.alpha = to;
    }
}
