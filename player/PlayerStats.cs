using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Vida")]
    public float maxHealth = 100f;
    public float currentHealth;

    [Header("Stamina (para sprint)")]
    public float maxStamina = 100f;
    public float currentStamina;
    public float staminaRegenRate = 15f;
    public float staminaDrainRate = 25f;

    PlayerSprint sprint;

    void Start()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;

        sprint = GetComponent<PlayerSprint>();
    }

    void Update()
    {
        HandleStamina();
    }

    // ================================
    // VIDA
    // ================================

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth <= 0)
            Die();
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    void Die()
    {
        Debug.Log("Player morreu!");
        // Aqui você pode colocar:
        // animação, respawn, game over, etc
    }

    // ================================
    // STAMINA
    // ================================

    void HandleStamina()
    {
        if (sprint != null && sprint.isSprinting)
        {
            currentStamina -= staminaDrainRate * Time.deltaTime;
        }
        else
        {
            currentStamina += staminaRegenRate * Time.deltaTime;
        }

        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
    }

    public bool HasStaminaToSprint()
    {
        return currentStamina > 5f;
    }
}
