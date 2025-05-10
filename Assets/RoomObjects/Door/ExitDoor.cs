using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour {

    private AudioSource audio;
    
    private void Start() {
        audio = GetComponent<AudioSource>();
        if (audio == null) {
            Debug.LogError("AudioSource component not found on the GameObject.");
        }
    }
    
    public void PlayOpenSound() {
        if (audio != null) {
            audio.Play();
        } else {
            Debug.LogWarning("AudioSource is not assigned.");
        }
    }

    public void ExitMuseum() {
        SceneManager.LoadScene("Scene/RewindSpace");
    }

}