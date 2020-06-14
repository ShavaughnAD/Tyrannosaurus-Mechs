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
            Debug.LogError("Immune");
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