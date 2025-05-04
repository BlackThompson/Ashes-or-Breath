using UnityEngine;

public class CatController : MonoBehaviour
{
    public CatMovement movement;
    public CatAnimatorController anim;

    private enum CatState { Idle, Walking, MeowingOrScruffed }
    private CatState currentState;

    private Vector3 currentDir;
    private float stateTimer;
    
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource not found on CatController.");
        }
        SwitchToIdle(); // 从Idle开始更自然
    }

    void Update()
    {
        stateTimer -= Time.deltaTime;
        // Debug.DrawRay(transform.position + Vector3.up * 0.1f, currentDir * 0.4f, Color.red);


        switch (currentState)
        {
            case CatState.Idle:
                anim.SetWalking(false);
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
                anim.SetWalking(true);

                if (stateTimer <= 0f)
                    SwitchToIdle();
                break;
            case CatState.MeowingOrScruffed:
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

    public void Meow() {
        currentState = CatState.MeowingOrScruffed;
        anim.SetMeowing();
    }
    
    public void PlaySound()
    {
        Debug.Log("PlaySound");
        if (audioSource != null)
        {
            audioSource.Play();
        }
        else {
            Debug.LogError("AudioSource not found on CatController.");
        }
    }
}
