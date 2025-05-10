using UnityEngine;

public class FloatingMotion : MonoBehaviour
{
    public float floatSpeed = 0.5f;      // 漂浮速度
    public float floatAmplitude = 0.1f; // 漂浮幅度（上下范围）
    public bool randomOffset = true;   // 是否每个物体有不同相位

    private Vector3 startPos;
    private float offset;

    void Start()
    {
        startPos = transform.position;
        offset = randomOffset ? Random.Range(0f, 100f) : 0f;
    }

    void Update()
    {
        float newY = Mathf.Sin(Time.time * floatSpeed + offset) * floatAmplitude;
        transform.position = startPos + new Vector3(0f, newY, 0f);
    }
}
