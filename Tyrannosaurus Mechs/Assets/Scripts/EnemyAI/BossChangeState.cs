using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChangeState : Health
{
    public int killScore;
    public bool isBoss = false;

    public float stageOneHealth = 225;
    public float stageTwoHealth = 100;
    public float stageThreeHealth = 50;

    public BossFirePattern2 bossFirePattern2;
    public BossFireBullets bossFireBullets;
    public BossFireDoubleSpiral bossDoubleSpiral;

    [Range(0.1f, 0.5f)]
    public float blinkEffectTime = 0.5f; //The lower this value, the faster the blink
    Material matBlink;
    Material matDefault;
    SpriteRenderer spriteRend;

    public enum Stage
    {
        Stage_1,
        Stage_2,
        Stage_3,
    }

    private Stage stage;

    public override void Awake()
    {
        base.Awake();
        bossFirePattern2 = GetComponent<BossFirePattern2>();
        bossFireBullets = GetComponent<BossFireBullets>();
        bossDoubleSpiral = GetComponent<BossFireDoubleSpiral>();
    }

    private void Start()
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
        CheckStage();

    }

    void CheckStage()
    {
        if(currentHealth <= 200)
        {
            bossFirePattern2.enabled = false;
            bossDoubleSpiral.enabled = true;
        }

        if (currentHealth <= 100)
        {
            bossFirePattern2.enabled = false;
            bossFireBullets.enabled = true;
        }

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
        GameManager.gameManager.score += killScore;

        if (isBoss == true)
        {
            gameObject.SetActive(false);
            Invoke("LoadMenu", .5f);
            GameManager.gameManager.LevelCompleted();
            GameManager.gameManager.GameWon();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void ResetMaterial()
    {
        spriteRend.material = matDefault;
    }

    void StageSettings()
    {

    }
}
