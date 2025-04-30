using UnityEngine;

public class SceneManager : MonoBehaviour {

    private CatController cat;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        cat = FindObjectOfType<CatController>();
        if (cat == null) {
            Debug.LogError("CatController not found in the scene.");
            return;
        }
        // 十秒后调用Fire
        Invoke("Fire", 10f);
    }
    
    void Fire() {
        // 让猫咪开始叫
        cat.Meow();
    }

}