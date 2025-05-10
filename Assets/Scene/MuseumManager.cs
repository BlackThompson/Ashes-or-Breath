using UnityEngine;

public enum HoldingState {
    Cat,
    Art,
    Nothing
}

public class MuseumManager : MonoBehaviour {

    public GameObject fire;
    public static HoldingState holdingState;
    // 设置时间
    public float fireTime = 50.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        Debug.Log("Count Down 10s");
        Invoke("Fire", fireTime);
        holdingState = HoldingState.Nothing;
    }

    void Fire() {
        CatController cat = FindObjectOfType<CatController>();
        if (cat == null) {
            Debug.LogError("CatController not found in the scene.");
            return;
        }
        Latern latern = FindObjectOfType<Latern>();
        if (latern == null) {
            Debug.LogError("Latern not found in the scene.");
            return;
        }
        latern.DropBoom();
        fire.SetActive(true);
        cat.Meow();
    }

    public static void SetHoldingStateCat() {
        holdingState = HoldingState.Cat;
    }

    public static void SetHoldingStateArt() {
        holdingState = HoldingState.Art;
    }

    public static void SetHoldingStateNothing() {
        holdingState = HoldingState.Nothing;
    }

}