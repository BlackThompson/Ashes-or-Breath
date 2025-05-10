using UnityEngine;

public class RewindManager : MonoBehaviour {

    public RewindDoor door;

    public GameObject catFlag;
    public GameObject artFlag;
    public GameObject saveCatBubble;
    public GameObject saveArtBubble;

    void Start() {
        if (MuseumManager.holdingState == HoldingState.Nothing) {
            catFlag.SetActive(false);
            artFlag.SetActive(false);
            saveCatBubble.SetActive(true);
            saveArtBubble.SetActive(true);
        }
        else if (MuseumManager.holdingState == HoldingState.Cat) {
            catFlag.SetActive(true);
            artFlag.SetActive(false);
            saveCatBubble.SetActive(true);
            saveArtBubble.SetActive(false);
        }
        else if (MuseumManager.holdingState == HoldingState.Art) {
            catFlag.SetActive(false);
            artFlag.SetActive(true);
            saveCatBubble.SetActive(false);
            saveArtBubble.SetActive(true);
        }
        else {
            Debug.LogError("Invalid holding state.");
        }
    }

    public void LetPlayerDecide() {
        // 启用 RewindDoor
        if (door != null) {
            door.gameObject.SetActive(true);
        }
        else {
            Debug.LogError("RewindDoor is not assigned or found in the scene.");
        }
    }

}