using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : Health
{
    public int killScore;
    public bool isBoss = false;
    public BossFirePattern2 BFP2;
    public BossFireDoubleSpiral BFPDS;
    public BossFireBullets BFB;
    public Dropitem dropItem;
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

    public override void TakeDamage(float damageAmount)
    {
        base.TakeDamage(damageAmount);
        currentHealth = Mathf.Clamp(currentHealth - damageAmount, 0, maxHealth);
        if(currentHealth == 0)
        {
            dropItem.LootDrop();
            Death();
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

    //void Hurt(float param)
    //{

    //}

    //void Death(float param)
    //{
    //    //ScoreSystem.Instance.AddScore(killScore);
    //    Destroy(gameObject);
    //}
}
