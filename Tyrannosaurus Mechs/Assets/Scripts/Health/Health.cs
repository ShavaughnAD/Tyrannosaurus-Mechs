using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 0;
    public float currentHealth = 0;
    public float damageTaken = 0;
    public float healingRecieved = 0;
    public float damageReduction = 1; //Will be used to divide the damageAmount. Example, if the player gets hit with 5 damage, they will instead take 2.5

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
        if (currentHealth <= 0) return;
        currentHealth = Mathf.Clamp(currentHealth - damageAmount, 0, maxHealth);
        if (currentHealth == 0)
        {
            onDeath.CallEvent(0);
        }
        else
        {
            damageTaken = damageAmount;
            onHurt.CallEvent(currentHealth / maxHealth);   
        }
    }

    public virtual void ResetHealth()
    {
        currentHealth = maxHealth;
    }

    public void Healing(float healingAmount)
    {
        healingRecieved = healingAmount;
        onHeal.CallEvent(0);
        currentHealth += healingAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}