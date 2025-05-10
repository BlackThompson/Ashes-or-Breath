using UnityEngine;
using TMPro;


public class CanvasController : MonoBehaviour
{
    public GameObject touchImage;  // UI Image GameObject
    public TMP_Text touchText;     // TMP Text component

    void Start()
    {
        touchImage.SetActive(false);
        // touchText.gameObject.SetActive(false);
        touchText.text = "Grab the Bubbles to Reflect Your Choice \n\n Then Look Back at the Rewind Door \n\n You Can Remake Your Choice";
    }

}
