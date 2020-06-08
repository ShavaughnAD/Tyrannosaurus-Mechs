using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public int killScore;
    public override void Awake()
    {
        base.Awake();
        //onHurt.BindToEvent(Hurt);
        //onDeath.BindToEvent(Death);
        gameObject.layer = 10;
        ResetHealth();
    }

    public override void TakeDamage(float damageAmount)
    {
        base.TakeDamage(damageAmount);
        currentHealth = Mathf.Clamp(currentHealth - damageAmount, 0, maxHealth);
        if(currentHealth == 0)
        {
            Death();
        }
    }

    void Death()
    {
        //Increase score here
        Destroy(gameObject);
    }

    //void Hurt(float param)
    //{

    //}

    //void Death(float param)
    //{
    //    //ScoreSystem.Instance.AddScore(killScore);
    //    Destroy(gameObject);
    //}
}
