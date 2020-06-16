using UnityEngine;

public class AstroidHealth : Health
{
    public GameObject astroidMedium;
    public Transform spawnP;

    #region BlinkingEffect Variables

    [Range(0.1f, 0.5f)]
    public float blinkEffectTime = 0.5f; //The lower this value, the faster the blink
    Material matBlink;
    Material matDefault;
    SpriteRenderer spriteRend;

    #endregion

    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        matBlink = Resources.Load("Effects/Blink", typeof(Material)) as Material;
        matDefault = spriteRend.material;
    }

    public override void TakeDamage(float damageAmount)
    {
        base.TakeDamage(damageAmount);
        currentHealth = Mathf.Clamp(currentHealth - damageAmount, 0, maxHealth);
        spriteRend.material = matBlink;
        if (currentHealth == 0)
        {
            Death();
        }
        else
        {
            Invoke("ResetMaterial", blinkEffectTime);
        }
    }

    void Death()
    {
        for (int i = 0; i < 1; i++)
        {
            Instantiate(astroidMedium, spawnP.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void ResetMaterial()
    {
        spriteRend.material = matDefault;
    }

}
