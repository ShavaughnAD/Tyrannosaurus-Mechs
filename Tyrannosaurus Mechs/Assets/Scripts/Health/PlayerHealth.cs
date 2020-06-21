using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    public Text healthText;
    public Vector3 respawnPoint;

    public AudioClip sDamage;
    public AudioSource auSource;

    public Animator playerAnimator;

    public GameObject explosionEfx;
    public override void Awake()
    {
        base.Awake();
        playerAnimator = GetComponent<Animator>();
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
            Death();
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

    public void Death()
    {
        playerAnimator.SetBool("isDamaged", false);
        playerAnimator.applyRootMotion = false;
        GetComponent<PlayerMovement>().enabled = false;
        playerAnimator.SetBool("isDead", true);
        //Respawn();
        GameObject explosion = Instantiate(explosionEfx, transform.position, Quaternion.identity);
    }    
}
