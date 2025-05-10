using UnityEngine;

public class CatInteraction : MonoBehaviour
{
    public string targetTag = "Cube";
    public float walkSpeed = 0.15f;
    public float stopDistance = 0.15f;
    public float jumpSpeed = 2f; // 提高跳跃速度（不然太慢）
    public Transform modelTransform;
    public float facingOffset = 0f;

    private Transform targetCube;
    private Animator animator;
    private bool isJumping = false;
    private bool reachedTop = false;

    void Start()
    {
        animator = modelTransform.GetComponent<Animator>();
        GameObject found = GameObject.FindGameObjectWithTag(targetTag);
        if (found != null)
        {
            targetCube = found.transform;
        }
    }

    void Update()
    {
        if (targetCube == null || isJumping || reachedTop) return;

        Vector3 cubeFront = targetCube.position - targetCube.forward * stopDistance;
        Vector3 direction = cubeFront - transform.position;
        float distance = direction.magnitude;

        if (distance > 0.1f)
        {
            transform.position += direction.normalized * walkSpeed * Time.deltaTime;

            Quaternion lookRot = Quaternion.LookRotation(direction);
            lookRot *= Quaternion.Euler(0, facingOffset, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, 5f * Time.deltaTime);

            animator.SetBool("isWalking", true);
            animator.SetBool("isJumping", false);
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isJumping", true);

            StartCoroutine(JumpOntoCube());
        }
    }

    System.Collections.IEnumerator JumpOntoCube()
{
    isJumping = true;

    Vector3 startPos = transform.position;

    float cubeHeight = targetCube.localScale.y;
    Renderer modelRenderer = modelTransform.GetComponentInChildren<Renderer>();
    float modelHeight = modelRenderer.bounds.size.y;
    float cubeTopY = targetCube.position.y + cubeHeight / 2f + modelHeight / 2f;
    Vector3 endPos = new Vector3(
        targetCube.position.x,
        cubeTopY,
        targetCube.position.z
    );

    float heightDifference = Mathf.Max(cubeTopY - startPos.y, 0.1f);
    float jumpHeight = heightDifference + 0.05f; // 稍微高于顶部

    float jumpDuration = 1f;
    float time = 0f;

    while (time < jumpDuration)
    {
        time += Time.deltaTime * jumpSpeed;
        float t = Mathf.Clamp01(time / jumpDuration);

        float heightOffset = Mathf.Sin(t * Mathf.PI) * jumpHeight;
        Vector3 currentPos = Vector3.Lerp(startPos, endPos, t) + Vector3.up * heightOffset;

        transform.position = currentPos;
        yield return null;
    }

    transform.position = endPos;

    animator.SetBool("isJumping", false);
    animator.SetBool("isWalking", false);

    isJumping = false;
    reachedTop = true;
}}

