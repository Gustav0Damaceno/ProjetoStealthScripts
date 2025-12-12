using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    Animator animator;

    PlayerMovement movement;
    PlayerSprint sprint;
    PlayerCrouch crouch;
    PlayerJump jump;

    void Start()
    {
        animator = GetComponent<Animator>();

        movement = GetComponentInParent<PlayerMovement>();
        sprint = GetComponentInParent<PlayerSprint>();
        crouch = GetComponentInParent<PlayerCrouch>();
        jump   = GetComponentInParent<PlayerJump>();
    }

    void Update()
    {
        UpdateAnimations();
    }

    void UpdateAnimations()
    {
        float speed = movement.velocity.magnitude;

        animator.SetFloat("Speed", speed);  
        animator.SetBool("IsSprinting", sprint.isSprinting);
        animator.SetBool("IsCrouching", crouch.isCrouching);
        animator.SetBool("IsGrounded", jump.GetComponent<CharacterController>().isGrounded);
    }

    // Chame isso quando pular
    public void TriggerJump()
    {
        animator.SetTrigger("Jump");
    }
}
