using UnityEngine;

public class RewindManager : MonoBehaviour {

    public RewindDoor door;

    public GameObject catFlag;
    public GameObject artFlag;

    void Start() {
        if (MuseumManager.holdingState == HoldingState.Nothing) {
            catFlag.SetActive(false);
            artFlag.SetActive(false);
        }
        else if (MuseumManager.holdingState == HoldingState.Cat) {
            catFlag.SetActive(true);
            artFlag.SetActive(false);
        }
        else if (MuseumManager.holdingState == HoldingState.Art) {
            catFlag.SetActive(false);
            artFlag.SetActive(true);
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