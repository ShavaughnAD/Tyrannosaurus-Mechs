using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : Health
{
    public int killScore;
    public bool isBoss = false;
    public override void Awake()
    {
        base.Awake();
        //onHurt.BindToEvent(Hurt);
        //onDeath.BindToEvent(Death);
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
        GameManager.gameManager.score += killScore;
        if(isBoss == true)
        {
            gameObject.SetActive(false);
            Invoke("LoadMenu", 2);
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

    //void Hurt(float param)
    //{

    //}

    //void Death(float param)
    //{
    //    //ScoreSystem.Instance.AddScore(killScore);
    //    Destroy(gameObject);
    //}
}
