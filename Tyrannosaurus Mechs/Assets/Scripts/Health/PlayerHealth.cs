using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Health
{
    public Text healthText;
    public Vector3 respawnPoint;

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

    //void Respawn()
    //{
    //    transform.position = respawnPoint;
    //    currentHealth = maxHealth;
    //}
}
