using System;
using Oculus.Interaction.HandGrab;
using UnityEngine;

public class Latern : MonoBehaviour {

    public GameObject boom;

    private void Start() { 
        Debug.Log("Latern Start");
    }

    public void DropBoom() {
        boom.GetComponent<Rigidbody>().useGravity = true;
    }

}