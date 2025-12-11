using UnityEngine;

public class PlayerStealth : MonoBehaviour
{
    PlayerMovement move;
    
    public bool IsStealthing => movement.isCrouching;

    void Start()
    {
        move = GetComponent<PlayerMovement>();
    }
}
