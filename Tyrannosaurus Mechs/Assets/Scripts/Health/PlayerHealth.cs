using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    public Text healthText;
    public Vector3 respawnPoint;

    public AudioClip sDamage;
    public AudioSource auSource;

    public Animator playerAnimator;
    public override void Awake()
    {
        base.Awake();
        onDeath.BindToEvent(Death);
    }

    void Update()
    {
        //healthText.text = currentHealth.ToString("0");
    }

    void Start()
    {
        GameRestart();
    }

    public override void TakeDamage(float damageAmount)
    {
        base.TakeDamage(damageAmount);
        currentHealth = Mathf.Clamp(currentHealth - damageAmount, 0, maxHealth);


        //auSource.PlayOneShot(sDamage);
        playerAnimator.SetBool("isDamaged",true);
        if (currentHealth == 0)
        {
            
        }
        else
        {
            
        }
    }
    void GameRestart()
    {
        respawnPoint = transform.position;
    }
    public void SetRespawnPoint(Transform transform)
    {
        respawnPoint = transform.position;
    }

    void Death(float param)
    {
        //Respawn();
    }    
}
