using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerCrouch : MonoBehaviour
{
    public float crouchHeight = 1.0f;
    public float standHeight = 1.8f;
    public float crouchSpeedMultiplier = 0.6f;

    public bool isCrouching;

    private CharacterController controller;
    private PlayerMovement movement;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        movement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        HandleCrouch();
    }

    void HandleCrouch()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            isCrouching = true;
            controller.height = crouchHeight;
            movement.walkSpeed = 3.5f * crouchSpeedMultiplier;
        }
        else
        {
            isCrouching = false;
            controller.height = standHeight;
            movement.walkSpeed = 3.5f;
        }
    }
}
