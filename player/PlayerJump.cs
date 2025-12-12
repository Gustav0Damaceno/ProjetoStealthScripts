using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 6f;
    public float gravity = -9.81f;

    private Vector3 fallVelocity;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        ApplyGravity();
        HandleJump();
    }

    void ApplyGravity()
    {
        if (controller.isGrounded && fallVelocity.y < 0)
            fallVelocity.y = -2f;

        fallVelocity.y += gravity * Time.deltaTime;
        controller.Move(fallVelocity * Time.deltaTime);
    }

    void HandleJump()
    {
        if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            fallVelocity.y = jumpForce;
        }
    }
}
