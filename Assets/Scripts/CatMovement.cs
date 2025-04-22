using UnityEngine;

public class CatMovement : MonoBehaviour
{
    public float walkSpeed = 0.15f;
    public float rotationSpeed = 2f;

    public void MoveTowards(Vector3 direction)
    {
        direction.y = 0;
        transform.position += direction.normalized * walkSpeed * Time.deltaTime;

        if (direction != Vector3.zero)
        {
            Quaternion targetRot = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);
        }
    }
}
