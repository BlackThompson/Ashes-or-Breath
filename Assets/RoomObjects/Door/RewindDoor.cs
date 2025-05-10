using TMPro; // 必须加上这行
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RewindDoor : MonoBehaviour {

    public GameObject countDown;
    private int timeToDecide = 180;

    void Start() {
        if (countDown == null) {
            Debug.LogError("CountDown prefab is not assigned.");
        }
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown() {
        while (timeToDecide > 0) {
            countDown.GetComponent<TMP_Text>().text = "You have " + timeToDecide + " seconds to decide!";
            timeToDecide--;
            yield return new WaitForSeconds(1.0f);
        }
        Application.Quit();
    }

    public void RewindTime() {
        // 打开 Room 文件夹下的 Museum 场景
        SceneManager.LoadScene("Scene/MuseumFired");
    }

}