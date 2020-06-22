using UnityEngine;

public class EnemyHealth : Health
{
    public int killScore;
    public bool isBoss = false;
    public Dropitem dropItem;
    public GameObject damageFloater;

    #region Blinking Effect Variables

    [Range(0.1f, 0.5f)]
    public float blinkEffectTime = 0.5f; //The lower this value, the faster the blink
    Material matBlink;
    Material matDefault;
    SpriteRenderer spriteRend;

    #endregion

    public override void Awake()
    {
        base.Awake();
        ResetHealth();
        dropItem = GetComponent<Dropitem>();
    }

    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
        matBlink = Resources.Load("Effects/Blink", typeof(Material)) as Material;
        matDefault = spriteRend.material;
    }

    public override void TakeDamage(float damageAmount)
    {
        base.TakeDamage(damageAmount);
        damageTaken = damageAmount;
        currentHealth = Mathf.Clamp(currentHealth - damageAmount, 0, maxHealth);
        spriteRend.material = matBlink;
        if(currentHealth == 0)
        {
            Death();
        }
        else
        {
            if(damageFloater != null)
            {
                ShowFloatingText();
            }
            Invoke("ResetMaterial", blinkEffectTime);
        }
    }

    void Death()
    {
        GameManager.gameManager.score += killScore;
        dropItem.LootDrop();
        Destroy(gameObject);
    }

    void ShowFloatingText()
    {
        GameObject floatingText = Instantiate(damageFloater, transform.position, Quaternion.identity);
        floatingText.transform.GetChild(0).GetComponent<TextMesh>().text = damageTaken.ToString("F0");
    }

    void ResetMaterial()
    {
        spriteRend.material = matDefault;
    }
}
