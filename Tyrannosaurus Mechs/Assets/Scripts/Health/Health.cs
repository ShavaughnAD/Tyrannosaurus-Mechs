using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 0;
    public float currentHealth = 0;
    public float damageTaken = 0;

    public bool immune;

    public HealthDelegate onHurt = new HealthDelegate();
    public HealthDelegate onDeath = new HealthDelegate();
    public HealthDelegate onHeal = new HealthDelegate();

    public virtual void Awake()
    {
        ResetHealth();
    }

    public virtual void TakeDamage(float damageAmount)
    {
        if (immune)
        {
            return;
        }
        else
        {
            if(gameObject.tag == "Player")
            {
                GameManager.gameManager.GameOver();
            }
            else
            {
                onHurt.CallEvent(0);
            }
        }
    }

    public virtual void ResetHealth()
    {
        currentHealth = maxHealth;
    }
}