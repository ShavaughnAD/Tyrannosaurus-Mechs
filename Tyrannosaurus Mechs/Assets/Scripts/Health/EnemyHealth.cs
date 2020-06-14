﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : Health
{
    public int killScore;
    public bool isBoss = false;
    [HideInInspector] public BossFirePattern2 BFP2;
    [HideInInspector] public BossFireDoubleSpiral BFPDS;
    [HideInInspector] public BossFireBullets BFB;
    public Dropitem dropItem;

    [Range(0.1f, 0.5f)]
    public float blinkEffectTime = 0.5f; //The lower this value, the faster the blink
    Material matBlink;
    Material matDefault;
    SpriteRenderer spriteRend;
    public override void Awake()
    {
        base.Awake();
        //onHurt.BindToEvent(Hurt);
        //onDeath.BindToEvent(Death);
        ResetHealth();
        dropItem = GetComponent<Dropitem>();
        if (isBoss == true)
        {
            BFB = GetComponent<BossFireBullets>();
            BFP2 = GetComponent<BossFirePattern2>();
            BFPDS = GetComponent<BossFireDoubleSpiral>();
            dropItem.enabled = true;
        }
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
        currentHealth = Mathf.Clamp(currentHealth - damageAmount, 0, maxHealth);
        spriteRend.material = matBlink;
        if(currentHealth == 0)
        {
            dropItem.LootDrop();
            Death();
        }
        else
        {
            Invoke("ResetMaterial", blinkEffectTime);
        }
    }

    void Death()
    {
        GameManager.gameManager.score += killScore;

        if(isBoss == true)
        {
            gameObject.SetActive(false);
            Invoke("LoadMenu", .5f);
            BFB.enabled = false;
            BFP2.enabled = false;
            BFPDS.enabled = false;
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    void ResetMaterial()
    {
        spriteRend.material = matDefault;
    }
}
