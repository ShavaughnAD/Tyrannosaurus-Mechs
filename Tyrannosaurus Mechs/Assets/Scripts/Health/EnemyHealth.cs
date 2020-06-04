using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public int killScore;
    public override void Awake()
    {
        base.Awake();
        onHurt.BindToEvent(Hurt);
        onDeath.BindToEvent(Death);
        gameObject.layer = 10;
    }

    void Hurt(float param)
    {

    }

    void Death(float param)
    {
        //ScoreSystem.Instance.AddScore(killScore);
        Destroy(gameObject);
    }
}
