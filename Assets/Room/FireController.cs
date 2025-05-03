using UnityEngine;

public class FireController : MonoBehaviour {

    public GameObject fire;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        Debug.Log("Count Down 10s");
        Invoke("Fire", 10f);
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

}