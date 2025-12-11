using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;

    [Header("Velocidades")]
    public float walkSpeed = 3f;
    public float runSpeed = 6f;
    public float crouchSpeed = 1.8f;
    public float stealthWalkSpeed = 2f; // velocidade no modo furtivo

    [Header("Agachar")]
    public float crouchHeight = 1f;
    public float normalHeight = 1.8f;
    public float crouchTransitionSpeed = 6f;

    [Header("Gravidade")]
    public float gravity = -9.81f;
    Vector3 velocity;

    public bool isRunning;
    public bool isCrouching;
    public bool isStealthMode;

    Transform cam;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        cam = Camera.main.transform;
    }

    void Update()
    {
        Move();
        Crouch();
        StealthMode();
    }

    void Move()
    {
        float speed = walkSpeed;

        if (isStealthMode)
            speed = stealthWalkSpeed;

        if (isCrouching)
            speed = crouchSpeed;

        if (Input.GetKey(KeyCode.LeftShift) && !isCrouching && !isStealthMode)
        {
            speed = runSpeed;
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // gravidade
        if (controller.isGrounded && velocity.y < 0)
            velocity.y = -2f;

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
            isCrouching = !isCrouching;

        float targetHeight = isCrouching ? crouchHeight : normalHeight;
        controller.height = Mathf.Lerp(controller.height, targetHeight, Time.deltaTime * crouchTransitionSpeed);
    }

    void StealthMode()
    {
        if (Input.GetKeyDown(KeyCode.C))
            isStealthMode = !isStealthMode;
    }
}
