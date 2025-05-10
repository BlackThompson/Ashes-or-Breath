using UnityEngine;

public class CatAnimatorController : MonoBehaviour {

    private Animator animator;

    void Awake() {
        animator = GetComponentInChildren<Animator>();
    }

    public void SetWalking(bool isWalking) {
        animator.SetBool("isWalking", isWalking);
    }

    public void SetJumping(bool isJumping) {
        animator.SetBool("isJumping", isJumping);
    }

    public void SetMeowing() {
        animator.SetBool("isWalking", false);
        animator.SetBool("isJumping", false);
        animator.SetBool("isIdle", false);
        animator.Play("meow");
    }

    public void SetScruffed() {
        animator.SetBool("isWalking", false);
        animator.SetBool("isJumping", false);
        animator.SetBool("isIdle", false);
        animator.Play("scruffed");
    }

}