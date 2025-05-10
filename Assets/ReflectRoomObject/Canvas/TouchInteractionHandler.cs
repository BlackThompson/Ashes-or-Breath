using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class TouchInteractionHandler : MonoBehaviour
{
    public GameObject touchImage;
    public TMP_Text touchText;

    private bool isProcessing = false;

    public void OnTouch()
    {
        if (isProcessing) return;

        StartCoroutine(TouchRoutine());
    }

    private IEnumerator TouchRoutine()
    {
        isProcessing = true;

        // 显示图片和文字
        touchImage.SetActive(true);
        touchText.text = "touching";
        touchText.gameObject.SetActive(true);

        // 等待10秒
        yield return new WaitForSeconds(20f);

        // 更新为“finishing touching”，隐藏图片
        touchImage.SetActive(false);
        touchText.text = "finishing touching";

        // 再等待1-2秒再隐藏文字（可选）
        yield return new WaitForSeconds(2f);
        touchText.gameObject.SetActive(false);

        isProcessing = false;
    }
}
