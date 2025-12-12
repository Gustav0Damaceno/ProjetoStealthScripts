using UnityEngine;

public class PlayerNoiseEmitter : MonoBehaviour
{
    public float baseNoise = 1f;

    PlayerMovement movement;
    PlayerSprint sprint;
    PlayerCrouch crouch;

    void Start()
    {
        movement = GetComponent<PlayerMovement>();
        sprint = GetComponent<PlayerSprint>();
        crouch = GetComponent<PlayerCrouch>();
    }

    public float GetNoise()
    {
        float noise = baseNoise;

        if (sprint.isSprinting) noise *= 2f;
        if (crouch.isCrouching) noise *= 0.5f;

        float speed = movement.velocity.magnitude;
        return noise * speed;
    }
}
