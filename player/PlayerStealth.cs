using UnityEngine;

public class PlayerStealth : MonoBehaviour
{
    public bool isStealth = false;

    PlayerCrouch crouch;
    PlayerSprint sprint;

    void Start()
    {
        crouch = GetComponent<PlayerCrouch>();
        sprint = GetComponent<PlayerSprint>();
    }

    void Update()
    {
        isStealth = crouch.isCrouching && !sprint.isSprinting;
    }

    public float GetStealthModifier()
    {
        if (isStealth) return 0.5f;
        return 1f;
    }
}
