using UnityEngine;

public class CatAnimatorRewinder : MonoBehaviour {
    private Animator animator;
    private CatAnimatorController catAnimatorController;

    private CatController catController;

    // private CatInteraction catMove;
    private CatMovement catMovement;

    public bool isPlayBack = false;

    float playbackTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        animator = GetComponent<Animator>();
        catAnimatorController = GetComponent<CatAnimatorController>();
        catController = GetComponent<CatController>();
        // catMove = GetComponent<CatInteraction>();
        catMovement = GetComponent<CatMovement>();
        // 判空
        if (animator == null) {
            Debug.LogError("Animator component not found!");
        }

        if (catAnimatorController == null) {
            Debug.LogError("CatAnimatorController component not found!");
        }

        if (catController == null) {
            Debug.LogError("CatController component not found!");
        }

        // if (catMove == null)
        // {
        //     Debug.LogError("CatMove component not found!");
        // }
        if (catMovement == null) {
            Debug.LogError("CatMovement component not found!");
        }

        // start recording
        StartRecording();
    }

    void StartRecording() {
        animator.StartRecording(0);
        // 启用catAnimatorController
        catAnimatorController.enabled = true;
        // 启用catController
        catController.enabled = true;
        // 启用catMove
        // catMove.enabled = true;
        // 启用catMovement
        catMovement.enabled = true;
        // 10秒后停止录制
        Invoke("StopRecording", 10f);
        // log
        Debug.Log("Recording started");
    }

    void StopRecording() {
        animator.StopRecording();
        // 禁用catAnimatorController
        catAnimatorController.enabled = false;
        // 禁用catController
        catController.enabled = false;
        // 禁用catMove
        // catMove.enabled = false;
        // 禁用catMovement
        catMovement.enabled = false;
        // 倒放录好的动画
        animator.StartPlayback();
        // log
        Debug.Log("Playback started");
        isPlayBack = true;
        playbackTimer = animator.recorderStopTime; // 从录制结束的地方开始倒放
    }

    // Update is called once per frame
    void Update() {
        if (isPlayBack) {
            playbackTimer -= Time.deltaTime; // 每帧减少
            if (playbackTimer <= animator.recorderStartTime) {
                animator.StopPlayback();
                isPlayBack = false;
                // 重新开始录制
                StartRecording();
            }
            else {
                playbackTimer = Mathf.Clamp(playbackTimer, animator.recorderStartTime, animator.recorderStopTime); // 防止小于最小时间
                animator.playbackTime = playbackTimer;
            }
        }
        
    }
}