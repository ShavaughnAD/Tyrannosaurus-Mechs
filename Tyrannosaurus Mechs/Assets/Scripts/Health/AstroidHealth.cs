using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidHealth : Health
{
    public GameObject astroidMedium;
    public Transform spawnP;


    public override void TakeDamage(float damageAmount)
    {
        base.TakeDamage(damageAmount);
        currentHealth = Mathf.Clamp(currentHealth - damageAmount, 0, maxHealth);
        if (currentHealth == 0)
        {
            Death();
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
}
