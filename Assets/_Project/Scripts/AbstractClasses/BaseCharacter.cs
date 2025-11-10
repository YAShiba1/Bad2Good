using UnityEngine;

public abstract class BaseCharacter : MonoBehaviour, IDamageable
{
    [SerializeField] protected int MaxHealth;
    [SerializeField] protected HealthBar HealthBar;

    protected int CurrentHealth;

    public void TakeDamage(int damage)
    {
        if (damage > 0 && damage <= CurrentHealth)
        {
            CurrentHealth -= damage;
        }

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            Die();
        }

        HealthBar.SetHealth(CurrentHealth);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
