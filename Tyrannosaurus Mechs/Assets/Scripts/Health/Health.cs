using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 0;
    public float currentHealth = 0;
    public float damageTaken = 0;

    bool invulnerable = false;
    public bool immune { get => invulnerable; set => invulnerable = value; }

    public HealthDelegate onHurt = new HealthDelegate();
    public HealthDelegate onDeath = new HealthDelegate();
    public HealthDelegate onHeal = new HealthDelegate();

    public virtual void Awake()
    {
        ResetHealth();
    }

    public virtual void TakeDamage(float damageAmount)
    {
        if (immune) return;
        onHurt.CallEvent(0);
        //if (currentHealth <= 0) return;
        //currentHealth = Mathf.Clamp(currentHealth - damageAmount, 0, maxHealth);
        //if (currentHealth == 0)
        //{
        //    onDeath.CallEvent(0);
        //}
        //else
        //{
        //    onHurt.CallEvent(currentHealth / maxHealth);   
        //}
    }

    public virtual void ResetHealth()
    {
        currentHealth = maxHealth;
    }
}