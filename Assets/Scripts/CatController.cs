using UnityEngine;

public class CatController : MonoBehaviour
{
    private CatMovement movement;
    private CatAnimatorController animatorController;

    private enum CatState { Idle, Walking }
    private CatState currentState;

    private Vector3 currentDir;
    private float stateTimer;

    void Start()
    {
        movement = GetComponent<CatMovement>();
        animatorController = GetComponent<CatAnimatorController>();
        SwitchToIdle(); // 从Idle开始更自然
    }

    void Update()
    {
        stateTimer -= Time.deltaTime;
        // Debug.DrawRay(transform.position + Vector3.up * 0.1f, currentDir * 0.4f, Color.red);


        switch (currentState)
        {
            case CatState.Idle:
                animatorController.SetWalking(false);
                if (stateTimer <= 0f)
                    SwitchToWalk();
                break;

            case CatState.Walking:
                // 碰到障碍就换方向
                // 射线长度为0.1f
                if (Physics.Raycast(transform.position + Vector3.up * 0.1f, currentDir, 0.1f))
                {
                    ChooseNewDirection();
                }

                movement.MoveTowards(currentDir);
                animatorController.SetWalking(true);

                if (stateTimer <= 0f)
                    SwitchToIdle();
                break;
        }
    }

    void ChooseNewDirection()
    {
        float angle = Random.Range(0f, 360f);
        currentDir = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)).normalized;
    }

    void SwitchToIdle()
    {
        currentState = CatState.Idle;
        stateTimer = Random.Range(1f, 3f); // 停 1~3 秒
    }

    void SwitchToWalk()
    {
        currentState = CatState.Walking;
        stateTimer = Random.Range(6f, 10f); // 走 3~6 秒
        ChooseNewDirection();
    }
}
