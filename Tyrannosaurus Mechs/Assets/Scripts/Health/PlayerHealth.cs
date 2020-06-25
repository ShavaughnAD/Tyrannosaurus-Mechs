using UnityEngine;

public class PlayerHealth : Health
{
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

    void Start()
    {
        GameRestart();
    }

    public override void TakeDamage(float damageAmount)
    {
        base.TakeDamage(damageAmount);
        if (immune)
        {
            Debug.LogError(gameObject.name + " is Immune");
            return;
        }
        playerAnimator.SetBool("isDamaged",true);
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

    public void SetImmunityTrue()
    {
        immune = true;
    }

    public void SetImmuneFalse()
    {
        Debug.Log("Called");
        playerAnimator.SetBool("isDamaged", false);
        immune = false;
    }
}
