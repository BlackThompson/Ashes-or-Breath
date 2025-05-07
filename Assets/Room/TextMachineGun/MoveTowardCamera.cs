using UnityEngine;
using UnityEngine;

public class MoveTowardCamera : MonoBehaviour {

    private float speed;

    public void Initialize(float sPeed) {
        this.speed = sPeed;
    }

    void Update() {
        transform.position += new Vector3(0, 0, -Mathf.Abs(speed)) * Time.deltaTime;
    }

}