using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    public Text healthText;
    public Vector3 respawnPoint;

    private Material blinkWhite;
    private Material blinkDefault;
    SpriteRenderer self;

    public AudioClip sDamage;
    public AudioSource auSource;
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
        self = GetComponent<SpriteRenderer>();
        blinkWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        blinkDefault = self.material;
    }

    public override void TakeDamage(float damageAmount)
    {
        base.TakeDamage(damageAmount);
        currentHealth = Mathf.Clamp(currentHealth - damageAmount, 0, maxHealth);

        self.material = blinkWhite;
        //auSource.PlayOneShot(sDamage);
        if (currentHealth == 0)
        {
            
        }
        else
        {
            Invoke("ResetMaterial", .1f);
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

    void ResetMaterial()
    {
        self.material = blinkDefault;
        auSource.PlayOneShot(sDamage);
    }
    
}
