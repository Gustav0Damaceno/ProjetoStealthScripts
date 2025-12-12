using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerSprint : MonoBehaviour
{
    public float sprintMultiplier = 1.8f;
    public bool isSprinting;

    private PlayerMovement movement;

    void Start()
    {
        movement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        HandleSprint();
    }

    void HandleSprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
            movement.walkSpeed = 3.5f * sprintMultiplier;
        }
        else
        {
            isSprinting = false;
            movement.walkSpeed = 3.5f;
        }
    }
}
