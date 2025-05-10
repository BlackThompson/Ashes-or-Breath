using TMPro; // 必须加上这行
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TextMachineGun : MonoBehaviour {

    public GameObject textPrefab;
    public float fireInterval = 0.5f;
    public float bulletLifetime = 5f;
    private float bulletSpeed;

    public List<string> phrasePool = new List<string>() {
        "Hello world", "Keep going", "Unity rocks",
        "Good luck", "Stay strong", "Be creative"
    };

    private HashSet<string> activePhrases = new HashSet<string>();

    void Start() {
        StartCoroutine(FireRoutine());
        bulletSpeed = Mathf.Abs( this.transform.position.z - Camera.main.transform.position.z ) / (bulletLifetime + 1.0f);
    }

    IEnumerator FireRoutine() {
        while (true) {
            FirePhrase();
            yield return new WaitForSeconds(fireInterval);
        }
    }

    void FirePhrase() {
        // log
        Debug.Log("FirePhrase");
        var available = phrasePool.Except(activePhrases).ToList();
        if (available.Count == 0) return;

        string selected = available[Random.Range(0, available.Count)];

        GameObject go = Instantiate(textPrefab, transform.position, Quaternion.identity);

        // 正确使用 TextMeshPro
        TMP_Text tmp = go.GetComponent<TMP_Text>();
        if (tmp != null) {
            tmp.text = selected;
        }

        go.AddComponent<MoveTowardCamera>().Initialize(bulletSpeed);
        activePhrases.Add(selected);
        StartCoroutine(RemoveAfterSeconds(go, selected, bulletLifetime));
    }

    IEnumerator RemoveAfterSeconds(GameObject go, string phrase, float time) {
        yield return new WaitForSeconds(time);
        activePhrases.Remove(phrase);
        Destroy(go);
    }

}